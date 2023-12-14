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
    private static float respawnChance= 0.2f;

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
            for(int i = 0; i < wayPoints.Count; i++)
            {
                if (wayPoints[i].gameObject.name.Equals(currentLocation))
                {
                    spawnPoint = wayPoints[i];
                    transform.position = spawnPoint.transform.position;
                }
            }
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
            
            kidRoomHandle.SetCurrentRoom(currentLocation);


            Debug.Log("Kid changed room and now in : " + currentLocation);
            sameRoom = currentLocation.Equals(SceneManager.GetActiveScene().name);
            if(sameRoom)
            {
                Debug.Log("Kid SPAWN");
                for(int i = 0; i < wayPoints.Count; i++)
                {
                    if (wayPoints[i].gameObject.name.Equals(currentLocation))
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

    
}

