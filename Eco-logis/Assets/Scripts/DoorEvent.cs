using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class DoorEvent : MonoBehaviour
{

    public string sceneToLoad;
    
    
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
        if (Input.GetKey(KeyCode.E))
        {
            LevelLoader levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
            StaticSceneTransi.PreviousSceneName = SceneManager.GetActiveScene().name;
            levelLoader.LoadNextRoom(SceneManager.GetActiveScene(), sceneToLoad);
        }
    }
    

}
