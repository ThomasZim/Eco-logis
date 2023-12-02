using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class kidBehaviour : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public float speed = 2f;
    int index;
    //bool notAtDestination = false;
    private bool playerInSight = false;
    //is the kid in the same room as the player
    private bool sameRoom; 
    private string currentLocation = "1st_floor";
    public float respawnChance= 0.1f;

    private float delayTimer = 0f;
    private float delayDuration = 2f;
    private GameObject spawnPoint;
    // TODO : make the logic work so that room changing is more realistic (no teleportation between rooms)
    // Current bug : when kid respawn he is also in the room from which he came
    void Start()
    {
        Debug.Log("SameRoom before: " + sameRoom);
        currentLocation = PlayerPrefs.GetString("currentLocation", currentLocation);
        Debug.Log("Current location: " + currentLocation);
        sameRoom = SceneManager.GetActiveScene().name.Equals(currentLocation);
        Debug.Log("SameRoom after: " + sameRoom);
        if (sameRoom == false)
        {

            InvokeRepeating("auto_roomChange", 0f, 2f);
        }
        else
        {
            CancelInvoke("auto_roomChange");
        }
        gameObject.SetActive(sameRoom);
        //currentLocation = PlayerPrefs.GetString("currentLocation", currentLocation);
        index = Random.Range(0, wayPoints.Count);
    }


    void Update()
    {
        //sameRoom = SceneManager.GetActiveScene().name.Equals(currentLocation);
        Vector3 destination = wayPoints[index].transform.position;
        //Update kid position and make it move if it is not seen by the player
        if(playerInSight == false && sameRoom == true)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, wayPoints[index].transform.position, speed * Time.deltaTime);
            transform.position = newPos;
        }

        float distance = Vector3.Distance(transform.position, destination);
        // Condition to make the kid change room 
        if(distance <= 0.05f && sameRoom == true && !wayPoints[index].gameObject.name.Contains("Sphere"))
        {

            // Increment the timer
            delayTimer += Time.deltaTime;

            // Check if the delay has been reached
            if (delayTimer >= delayDuration)
            {
                gameObject.SetActive(false);
                currentLocation = wayPoints[index].gameObject.name;
                PlayerPrefs.SetString("currentLocation", currentLocation);
                sameRoom = false;
                // Reset the timer
                delayTimer = 0f;
            }
            
        } 
        //Condition to make the kid change destination in the same room
        else if(distance <= 0.05f){
            ChangeIndex();
        }
        
        if (sameRoom == false)
        {
            InvokeRepeating("auto_roomChange", 0f, 2f);
        }
        else
        {
            CancelInvoke("auto_roomChange");
        }
        
    }
    
    void auto_roomChange()
    {
        float randomValue = Random.value;
        Debug.Log("Random value: " + randomValue);
        
        // condition to move room 
        if (randomValue > (1-respawnChance))
        {

            if(currentLocation.Equals("1st_floor"))
            {
                string[] possibleRooms = {"Garage", "Office", "Bathroom_1st", "2nd_floor "};
                currentLocation = possibleRooms[Random.Range(0, possibleRooms.Length)];    
                PlayerPrefs.SetString("currentLocation", currentLocation);            
            }
            else if(currentLocation.Equals("Garage") || currentLocation.Equals("Office") || currentLocation.Equals("Bathroom_1st"))
            {
                currentLocation = "1st_floor";
                PlayerPrefs.SetString("currentLocation", currentLocation);
            }
            else if(currentLocation.Equals("2nd_floor"))
            {
                string[] possibleRooms = {"Bathroom_2nd", "Child_room", "1st_floor"};
                currentLocation = possibleRooms[Random.Range(0, possibleRooms.Length)];    
                PlayerPrefs.SetString("currentLocation", currentLocation);            
            }
            else if(currentLocation.Equals("Bathroom_2nd") || currentLocation.Equals("Child_Room"))
            {
                currentLocation = "2nd_floor";
                PlayerPrefs.SetString("currentLocation", currentLocation);
            }
            Debug.Log("Kid now in room: " + currentLocation + currentLocation.Equals(SceneManager.GetActiveScene().name));
            
            
            if(currentLocation.Equals(SceneManager.GetActiveScene().name))
            {
                Debug.Log("Kid should appear");
                gameObject.SetActive(true);
                sameRoom = true;
                for(int i = 0; i < wayPoints.Count; i++)
                {
                    if (wayPoints[i].gameObject.name.Equals(currentLocation))
                    {
                        spawnPoint = wayPoints[i];
                        transform.position = spawnPoint.transform.position;
                    }
                }
                ChangeIndex();
                currentLocation = SceneManager.GetActiveScene().name;
                PlayerPrefs.SetString("currentLocation", currentLocation);
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
            ChangeIndex();
            Debug.Log("Collision with: " + other.gameObject.name);
            Debug.Log(SceneManager.GetActiveScene().name);
        }
        
    }

    private void ChangeIndex()
    {
        index = Random.Range(0, wayPoints.Count);
    }

     // Called by PlayerController when the player has the opponent in vision
    public void SetPlayerInSight(bool inSight)
    {
        playerInSight = inSight;
        Debug.Log("Is the kid in view :" + playerInSight);

    }

    
}

