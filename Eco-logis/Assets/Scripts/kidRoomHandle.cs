using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class kidRoomHandle : MonoBehaviour
{

    // Static variable to store the current room
    public static string currentRoom = "1st_floor";
    // Static function to set the current room
    public static void SetCurrentRoom(string roomName)
    {
        currentRoom = roomName;
        print("Kid current room is " + currentRoom);
    }

    // Static function to get the current room
    public static string GetCurrentRoom()
    {
        return currentRoom;
    }

    public static List<(float,string)> SortWaypointsByDistance(List<GameObject> localWayPoints)
    {
        // Create a list to store waypoints of scene where kid is currently in
        List<GameObject> currentWaypoints = new List<GameObject>();
        currentWaypoints = localWayPoints;
        // store specific point closest to the room where kid comes from
        GameObject originWayPoint = currentWaypoints.Find(waypoint => waypoint.name == SceneManager.GetActiveScene().name);
        // Calculate and store distances for each waypoint compared to orifinWayPoint
        
        List<(float, string)> distances = new List<(float,string)>();
        
        foreach (GameObject waypoint in currentWaypoints)
        {
            float distance = Vector3.Distance(originWayPoint.transform.position, waypoint.transform.position);
            string name = waypoint.name;
            distances.Add((distance, name));
        }

        // Sort the list based on distance
        distances.Sort((a, b) => a.Item2.CompareTo(b.Item2));
        // Make distance correspond to specific way point 
        
        return distances;
    }

    public static GameObject get_available_spawn_point(float number_authorized, List<GameObject> localWayPoints)
    {
        //get current room points
        List<GameObject> currentPoints = localWayPoints;
        // get current room points name sorted by distance
        List<(float,string)> spawnPoints = new List<(float,string)>();
        spawnPoints = SortWaypointsByDistance(currentPoints);

        // Create list of spawn points authorized based on the number_authorised
       List<GameObject> authorizedSpawnPoints = new List<GameObject>();

       // iterate through currentPoints and add to authorizedSpawnPoints based on the name in spawnPoints
       int index = 0;
        foreach (GameObject point in currentPoints)
        {
            if (point.name == spawnPoints[index].Item2)
            {
                authorizedSpawnPoints.Add(point);
                index++;
            }
        }
        
        return authorizedSpawnPoints[Random.Range(0, (int)number_authorized)];
        
    }

    

}
