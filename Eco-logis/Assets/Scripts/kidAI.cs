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

    // TODO : make the logic work so that room changing is more realistic (no teleportation between rooms)
    // TODO : make the way points every where

    void Start()
    {
        Debug.Log("SameRoom before: " + sameRoom);
        currentLocation = PlayerPrefs.GetString("currentLocation", currentLocation);
        Debug.Log("Current location: " + currentLocation);
        sameRoom = SceneManager.GetActiveScene().name.Equals(currentLocation);
        Debug.Log("SameRoom after: " + sameRoom);
        if (sameRoom == false)
        {
            InvokeRepeating("Respawn", 0f, 2f);
        }
        else
        {
            CancelInvoke("Respawn");
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
            gameObject.SetActive(false);
            currentLocation = wayPoints[index].gameObject.name;
            PlayerPrefs.SetString("currentLocation", currentLocation);
            sameRoom = false;
        } 
        //Condition to make the kid change destination in the same room
        else if(distance <= 0.05f){
            ChangeIndex();
        }
        
        if (sameRoom == false)
        {
            InvokeRepeating("Respawn", 0f, 2f);
        }
        else
        {
            CancelInvoke("Respawn");
        }
        
    }
    
    void Respawn()
    {
        float randomValue = Random.value;
        Debug.Log("Random value: " + randomValue);
        if (randomValue > (1-respawnChance))
        {
            gameObject.SetActive(true);
            sameRoom = true;
            transform.position = wayPoints[index].transform.position;
            ChangeIndex();
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

