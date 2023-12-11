using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
