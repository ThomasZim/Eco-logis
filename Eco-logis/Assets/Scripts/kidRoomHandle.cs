using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class kidRoomHandle : MonoBehaviour
{

    // Static variable to store the current room
    public static string currentRoom = "1st_floor";
    public static float distanceTimer = 1f;
    public static string oldRoom = "1st_floor";
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
    
    
    
    public static void SetOldRoom(string roomName)
    {
        oldRoom = roomName;
    }
    public static string GetoldRoom()
    {
        return oldRoom;
    }

    

    public static void distance_in_room()
    {
        distanceTimer += 1;
    }

    public static float get_distance_in_room()
    {
        return distanceTimer;
    }

    public static void Reset_distance()
    {
        distanceTimer = 1f;
    }

}
