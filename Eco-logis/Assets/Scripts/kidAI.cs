using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class kidBehaviour : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public float speed = 2f;
    public float rotationSpeed = 4f;
    int index;

    private bool canNotMove = false;
    //is the kid in the same room as the player
    private bool sameRoom; 
    private string currentLocation;
    private static float respawnChance= 0.1f;

    private float delayTimer = 0f;
    private float delayDuration = 2f;
    private GameObject spawnPoint;
    private string oldLocation;

    Animator animator;
    private bool enableAutoChange = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        currentLocation = kidRoomHandle.GetCurrentRoom();
        sameRoom = SceneManager.GetActiveScene().name.Equals(currentLocation);

        if (sameRoom == false)
        {
            InvokeRepeating("auto_roomChange", 0f, 2f);
        }
        else
        {
            CancelInvoke("auto_roomChange");
            //for(int i = 0; i < wayPoints.Count; i++)
            //{
            //    if (wayPoints[i].gameObject.name.Equals(currentLocation))
            //    {
            //        spawnPoint = wayPoints[i];
            //        transform.position = spawnPoint.transform.position;
            //    }
            //}

            spawnPoint = get_available_spawn_point(kidRoomHandle.get_distance_in_room(), wayPoints);
            kidRoomHandle.Reset_distance();
            transform.position = spawnPoint.transform.position;



            // spawnPoint = kidRoomHandle.get_available_spawn_point(distanceTimer, wayPoints);
            // transform.position = spawnPoint.transform.position;            
        }
        gameObject.SetActive(sameRoom);
        //currentLocation = PlayerPrefs.GetString("currentLocation", currentLocation);
        index = Random.Range(0, wayPoints.Count);
    }


    void Update()
    {

        //sameRoom = SceneManager.GetActiveScene().name.Equals(currentLocation);
        Vector3 destination = new Vector3(wayPoints[index].transform.position.x, 0f, wayPoints[index].transform.position.z);
        //Update kid position and make it move if it is not seen by the player
        
        if(canNotMove == false && sameRoom == true)
        {   
            animator.SetBool("IsWalking", true);
            // Calculate the rotation towards the destination
            Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
            // Smoothly rotate towards the destination
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;
        }
        if(canNotMove == true && sameRoom == true)
        {
            animator.SetBool("IsWalking", false);
        }

        float distance = Vector3.Distance(transform.position, destination);
        // Condition to make the kid change room 
        if(distance <= 0.05f && sameRoom == true && !wayPoints[index].gameObject.name.Contains("Sphere"))
        {
            animator.SetBool("IsWalking", false);
            // Increment the timer
            delayTimer += Time.deltaTime;

            // Check if the delay has been reached
            if (delayTimer >= delayDuration)
            {
                gameObject.SetActive(false);
                kidRoomHandle.SetOldRoom(currentLocation);
                currentLocation = wayPoints[index].gameObject.name;
                kidRoomHandle.SetCurrentRoom(currentLocation);
                oldLocation = SceneManager.GetActiveScene().name;

                sameRoom = false;
                // Reset the timer
                delayTimer = 0f;
            }
            
        } 
        //Condition to make the kid change destination in the same room
        else if(distance <= 0.05f){
             animator.SetBool("IsWalking", false);
             // Increment the timer
            delayTimer += Time.deltaTime;
            
            if (delayTimer >= delayDuration)
            {   
                ChangeIndex();
                delayTimer = 0f;
                animator.SetBool("IsWalking", true);

            }
        
        }
        
        if (sameRoom == false && enableAutoChange == false)
        {
            InvokeRepeating("auto_roomChange", 0f, 2f);
            //we invoke the function only once
            enableAutoChange = true;
        }  
        else if (sameRoom == true)
        {
            CancelInvoke("auto_roomChange");
            enableAutoChange = false;
        } 
       
    }

    void auto_roomChange()
    {
        kidRoomHandle.distance_in_room();

        float randomValue = Random.value;
        // Debug.Log("Random value: " + randomValue);
        // Debug.Log("Respawn chance: " + (1-respawnChance));
        // Debug.Log("respawn = " + (randomValue > (1-respawnChance)));
        // condition to move room 
        if (randomValue > (1-respawnChance))
        {
            // Debug.Log("Kid changed room");
            if(currentLocation.Equals("1st_floor"))
            {
                string[] possibleRooms = {"Garage", "Office", "Bathroom_1st", "2nd_floor", "buanderie_chauffage"};
                currentLocation = possibleRooms[Random.Range(0, possibleRooms.Length)];    
            }
            else if(currentLocation.Equals("Garage") || currentLocation.Equals("Office") || currentLocation.Equals("Bathroom_1st") || currentLocation.Equals("buanderie_chauffage"))
            {
                currentLocation = "1st_floor";
            }
            else if(currentLocation.Equals("2nd_floor"))
            {
                string[] possibleRooms = {"Bathroom_2nd", "Child_room", "1st_floor", "Adult_bedroom"};
                currentLocation = possibleRooms[Random.Range(0, possibleRooms.Length)];    
            }
            else if(currentLocation.Equals("Bathroom_2nd") || currentLocation.Equals("Child_room") || currentLocation.Equals("Adult_bedroom"))
            {
                currentLocation = "2nd_floor";
            }
            string oldLocation = kidRoomHandle.GetCurrentRoom();
            kidRoomHandle.SetOldRoom(oldLocation);
            kidRoomHandle.SetCurrentRoom(currentLocation);


            Debug.Log("Kid changed room and now in : " + currentLocation);
            sameRoom = currentLocation.Equals(SceneManager.GetActiveScene().name);


            if(sameRoom)
            {
                Debug.Log("Kid SPAWN");
                
                for(int i = 0; i < wayPoints.Count; i++)
                {
                    if (wayPoints[i].gameObject.name.Equals(kidRoomHandle.GetoldRoom()))
                    {
                        spawnPoint = wayPoints[i];
                        transform.position = spawnPoint.transform.position;
                    }
                }


                gameObject.SetActive(true);
                animator.SetBool("IsWalking", false);
                ChangeIndex();
            }
        }
        
        
    }
    

    // This function is called when a collision occurs.
    private void OnTriggerEnter(Collider other)
    {
        // Kid changes destination when collision with every thing except the floor and the waypoints
        if (wayPoints.Contains(other.gameObject) == false && other.gameObject.name.Contains("Floor") == false)
        {
            //change index immediately if random object
            // Debug.Log("Collision with :" + other.gameObject.name);
            ChangeIndex();
            // Debug.Log(SceneManager.GetActiveScene().name);
        }
        if (wayPoints.Contains(other.gameObject)) 
        {
            animator.SetBool("IsWalking", false);
        }
        
    }

    private void ChangeIndex()
    {
        index = Random.Range(0, wayPoints.Count);
    }

     // Called by PlayerController when the player has the opponent in vision
    public void SetPlayerInSight(bool inSight)
    {
        canNotMove = inSight;
        // Debug.Log("Is the kid in view :" + playerInSight);
    }

    public GameObject GetSpecificWayPoint(string WayPointName)
    {
        return wayPoints.Find(waypoint => waypoint.name == WayPointName);
    }

    public List<(float,string)> SortWaypointsByDistance(List<GameObject> localWayPoints)
    {
        // Create a list to store waypoints of scene where kid is currently in
        List<GameObject> currentWaypoints = new List<GameObject>();
        currentWaypoints = localWayPoints;
        
        // store specific point closest to the room where kid comes from
        GameObject originWayPoint = currentWaypoints.Find(waypoint => waypoint.name.Contains(kidRoomHandle.GetoldRoom()));
        // Calculate and store distances for each waypoint compared to orifinWayPoint
        
        List<(float, string)> distances = new List<(float,string)>();
        
        foreach (GameObject waypoint in currentWaypoints)
        {
            float distance = Vector3.Distance(originWayPoint.transform.position, waypoint.transform.position);
            string name = waypoint.name;
            distances.Add((distance, name));
        }

        // Sort the list based on distance
        distances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        // Make distance correspond to specific way point 
        
        return distances;
    }
    public GameObject get_available_spawn_point(float number_authorized, List<GameObject> localWayPoints)
    {
        // Get current room points
        List<GameObject> currentPoints = localWayPoints;

        // Get current room points name sorted by distance
        List<(float, string)> spawnPoints = SortWaypointsByDistance(currentPoints);

        // Create list of spawn points authorized based on the number_authorized
        List<GameObject> authorizedSpawnPoints = new List<GameObject>();
        // Iterate through spawnPoints and add to authorizedSpawnPoints based on the number_authorized
        for (int i = 0; i < number_authorized && i < spawnPoints.Count; i++)
        {
            GameObject spawnPoint = currentPoints.Find(point => point.name.Contains(spawnPoints[i].Item2));
            if (spawnPoint != null)
            {
                authorizedSpawnPoints.Add(spawnPoint);
            }
        }

        // Return a random authorized spawn point
        if (authorizedSpawnPoints.Count > 0)
        {
            return authorizedSpawnPoints[Random.Range(0, authorizedSpawnPoints.Count)];
        }
        else
        {
            return null; // No authorized spawn points available
        }
    }
    
    
}

