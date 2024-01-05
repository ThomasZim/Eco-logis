using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private string[] interactionPoints = {"lightGarageState", "heaterLaundryRoomState", "washMachineLaundryRoomState", "lightLaundryRoomState", "lavaboFloor1State", "lightBathFloor1State", "lightChildRoomState","lightBathFloor2State", "bathBathFloor2State", "lavaboBathFloor2State", "lightAdultRoomState", "lightFloor2State", "lightFloor1State", "tvFloor1State", "fridgeFloor1State", "ovenFloor1State"};

    Animator animator;
    private bool enableAutoChange = false;

    private bool doubleSpeed = false;
    private float speedTimer = 0f;

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
        
        if(sameRoom == true)
        {   
            animator.SetBool("IsWalking", true);
            // Calculate the rotation towards the destination
            Quaternion targetRotation = Quaternion.LookRotation(destination - transform.position);
            // Smoothly rotate towards the destination
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            if (doubleSpeed)
            {
                speedTimer += Time.deltaTime;
                // kid speed is doubled for 3 seconds
                if (speedTimer >= 3f)
                {
                    doubleSpeed = false;
                    speedTimer = 0f;
                    speed = 2f;
                }
            }
        }

        float distance = Vector3.Distance(transform.position, destination);
        //condition to make the kid interact with an object in same room and then go awaw
        if (distance <= 0.05f && sameRoom == true && interactionPoints.Contains(wayPoints[index].gameObject.name))
        {
            animator.SetBool("IsWalking", false);
            
             // Increment the timer
            delayTimer += Time.deltaTime;
            
            if (delayTimer >= delayDuration)
            {   
                // decides if kid will turn on an object or not 
                
                int kidRandAction = Random.Range(1, 101);

                Debug.Log("Kid random action : " + kidRandAction);
                Debug.Log("Kid interaction : " + CoreMechanics.kid);

                // CoreMechanics.kid at 100 = malicious kid interacts with object
                // CoreMechanics.kid at 0 = really nice kid DOES NOT interact with object
                //if (CoreMechanics.kid >= kidRandAction)

                    // Switch Case to include all the variables that rule the state of objects
                    switch (wayPoints[index].gameObject.name)
                    {
                        case "tvFloor1State":
                            if(CoreMechanics.tvFloor1State == false)
                            {
                                CoreMechanics.tvFloor1State = true;
                                Debug.Log("Changed TV to : " + CoreMechanics.tvFloor1State);
                            }
                            
                            break;
                        case "fridgeFloor1State":
                            if(CoreMechanics.fridgeFloor1State == false)
                            {
                                CoreMechanics.fridgeFloor1State = true;
                                Debug.Log("Changed Fridge to : " + CoreMechanics.fridgeFloor1State);    
                            }
                            break;
                        case "ovenFloor1State":
                            if(CoreMechanics.ovenFloor1State == false)
                            {
                                CoreMechanics.ovenFloor1State = true;
                                Debug.Log("Changed Oven to : " + CoreMechanics.ovenFloor1State);
                            }
                            break;
                        case "lightFloor1State":
                            if(CoreMechanics.lightFloor1State == false)
                            {
                                CoreMechanics.lightFloor1State = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightFloor1State);
                            }
                            break;
                        case "lightFloor2State":
                            if(CoreMechanics.lightFloor2State == false)
                            {
                                CoreMechanics.lightFloor2State = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightFloor2State);
                            }
                            break;
                        case "lightAdultRoomState":
                            if(CoreMechanics.lightAdultRoomState == false)
                            {
                                CoreMechanics.lightAdultRoomState = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightAdultRoomState);
                            }
                            break;
                        case "lavaboBathFloor2State":
                            if(CoreMechanics.lavaboBathFloor2State == false)
                            {
                                CoreMechanics.lavaboBathFloor2State = true;
                                Debug.Log("Changed lavabo to : " + CoreMechanics.lavaboBathFloor2State);
                            }
                            break;
                        case "bathBathFloor2State":
                            if(CoreMechanics.bathBathFloor2State == false)
                            {
                                CoreMechanics.bathBathFloor2State = true;
                                Debug.Log("Changed bath to : " + CoreMechanics.bathBathFloor2State);
                            }
                            break;
                        case "lightBathFloor2State":
                            if(CoreMechanics.lightBathFloor2State == false)
                            {
                                CoreMechanics.lightBathFloor2State = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightBathFloor2State);
                            }
                            break;

                        case "lightChildRoomState":
                            if(CoreMechanics.lightChildRoomState == false)
                            {
                                CoreMechanics.lightChildRoomState = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightChildRoomState);
                            }
                            break;  

                        case "lightBathFloor1State":
                            if(CoreMechanics.lightBathFloor1State == false)
                            {
                                CoreMechanics.lightBathFloor1State = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightBathFloor1State);
                            }
                            break;
                        
                        case "lavaboFloor1State":
                            if(CoreMechanics.lavaboFloor1State == false)
                            {
                                CoreMechanics.lavaboFloor1State = true;
                                Debug.Log("Changed lavabo to : " + CoreMechanics.lavaboFloor1State);
                            }
                            break;
                        
                        case "lightLaundryRoomState":
                            if(CoreMechanics.lightLaundryRoomState == false)
                            {
                                CoreMechanics.lightLaundryRoomState = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightLaundryRoomState);
                            }
                            break;

                        case "washMachineLaundryRoomState":
                            if(CoreMechanics.washMachineLaundryRoomState == false)
                            {
                                CoreMechanics.washMachineLaundryRoomState = true;
                                Debug.Log("Changed washMachine to : " + CoreMechanics.washMachineLaundryRoomState);
                            }
                            break;
                        
                        case "heaterLaundryRoomState":
                            if(CoreMechanics.heaterLaundryRoomState == false)
                            {
                                CoreMechanics.heaterLaundryRoomState = true;
                                Debug.Log("Changed heater to : " + CoreMechanics.heaterLaundryRoomState);
                            }
                            break;                       

                        case "lightGarageState":
                            if(CoreMechanics.lightGarageState == false)
                            {
                                CoreMechanics.lightGarageState = true;
                                Debug.Log("Changed light to : " + CoreMechanics.lightGarageState);
                            }
                            break;
                         
                        
                        // Add cases for other variables 
                        default:
                            // Handle unknown interaction point names or add additional cases
                            Debug.Log("Unknown interaction point name: " + wayPoints[index].gameObject.name);
                            break;
                    }

                ChangeIndex();
                delayTimer = 0f;
                animator.SetBool("IsWalking", true);

            }
        }
        // Condition to make the kid change room 
        else if(distance <= 0.05f && sameRoom == true && !wayPoints[index].gameObject.name.Contains("Sphere"))
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
        // Kid changes destination when collision with every thing except the floor and the waypoints and the interaction box colliders
        
        //TODO : HANDLE THE CASE WHEN COLLISION WITH INTERACTION OBJECT



        if (wayPoints.Contains(other.gameObject) == false && other.gameObject.name.Contains("Floor") == false)
        {
            //change index immediately if random object
            // Debug.Log("Collision with :" + other.gameObject.name);
            ChangeIndex();
            // Debug.Log(SceneManager.GetActiveScene().name);
        }



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
        //if kid collides with player, kid's speed doubles for '
        /*if (other.gameObject.name.Contains("Male"))
        {
            doubleSpeed = true;
            speed = 5f;
        }*/
        
    }

    private void ChangeIndex()
    {
        index = Random.Range(0, wayPoints.Count);
    }

     // Called by PlayerController when the player has the opponent in vision
    public void SetPlayerInSight(bool inSight)
    {
        CoreMechanics.kid = 0;
        // Debug.Log("Kid Becomes Real Nice");
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

