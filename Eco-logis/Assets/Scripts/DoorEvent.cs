using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player entered the Door");
        }
        if (Input.GetKey(KeyCode.E))
        {
            LevelLoader levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
            levelLoader.LoadNextLevel();
        }
    }
}
