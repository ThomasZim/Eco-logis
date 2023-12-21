using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    
    public float transitionTime = 1f;

    
    
    void Start()
    {
        // Get character
        GameObject character = GameObject.Find("MaleFreeSimpleMovement1");
        
        // Main menu
        if (StaticSceneTransi.inMainMenu)
        {
            character.transform.position = StaticSceneTransi.PreviousPosition;
            character.transform.rotation = StaticSceneTransi.PreviousRotation;
            StaticSceneTransi.inMainMenu = false;
        }
        else
        {
            // First floor
            if (SceneManager.GetActiveScene().name.Equals("1st_floor"))
            {
                Debug.Log("StaticSceneTransi.PreviousScene.name: " + StaticSceneTransi.PreviousSceneName);
                if (StaticSceneTransi.PreviousSceneName.Equals("Office"))
                {
                    character.transform.position = new Vector3(1.174f, 0f, -1.132f);
                    character.transform.rotation = Quaternion.Euler(0, 90, 0);
                }

                if (StaticSceneTransi.PreviousSceneName.Equals("Garage"))
                {
                    character.transform.position = new Vector3(-0.922f, 0f, 4.438f);
                    character.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                if (StaticSceneTransi.PreviousSceneName.Equals("Bathroom_1st"))
                {
                    character.transform.position = new Vector3(2.984f, 0f, 1.82f);
                    character.transform.rotation = Quaternion.Euler(0, -90, 0);
                }

                if (StaticSceneTransi.PreviousSceneName.Equals("2nd_floor"))
                {
                    character.transform.position = new Vector3(6.86f, 0f, -5.92f);
                    character.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                if (StaticSceneTransi.PreviousSceneName.Equals("buanderie_chauffage"))
                {
                    character.transform.position = new Vector3(2.409f, 0f, 4.532289f);
                    character.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }

            // Second floor
            if (SceneManager.GetActiveScene().name.Equals("2nd_floor"))
            {
                if (StaticSceneTransi.PreviousSceneName.Equals("1st_floor"))
                {
                    character.transform.position = new Vector3(1.9f, 0f, -1.649f);
                    character.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                if (StaticSceneTransi.PreviousSceneName.Equals("Child_room"))
                {
                    character.transform.position = new Vector3(1.429f, 0f, 4.438f);
                    character.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                if (StaticSceneTransi.PreviousSceneName.Equals("Adult_bedroom"))
                {
                    character.transform.position = new Vector3(-2.29f, 0f, 4.384f);
                    character.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                if (StaticSceneTransi.PreviousSceneName.Equals("Bathroom_2nd"))
                {
                    character.transform.position = new Vector3(-5.24f, 0f, 1.317f);
                    character.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }

            // Office
            if (SceneManager.GetActiveScene().name.Equals("Office"))
            {
                if (StaticSceneTransi.PreviousSceneName.Equals("Computer_menu"))
                {
                    character.transform.position = new Vector3(1.41f, 0f, 3.36f);
                    character.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // Reset scene
            Debug.Log("Resetting scene");
            LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StaticSceneTransi.inMainMenu = true;
            StaticSceneTransi.PreviousSceneName = SceneManager.GetActiveScene().name;
            StaticSceneTransi.PreviousPosition = GameObject.Find("MaleFreeSimpleMovement1").transform.position;
            StaticSceneTransi.PreviousRotation = GameObject.Find("MaleFreeSimpleMovement1").transform.rotation;
            SceneManager.LoadScene("Main_menu");
        }

        animUpdate();
    }
    public void LoadNextRoom(Scene actualScene, string nextScene)
    {
        if (!actualScene.name.Equals("1st_floor") && !actualScene.name.Equals("2nd_floor"))
        {
            if (actualScene.name.Equals("Bathroom_1st") || actualScene.name.Equals("Office") ||
                actualScene.name.Equals("Garage") || actualScene.name.Equals("buanderie_chauffage")) 
            {
                Debug.Log("Loading next scene: 1st_floor");
                StartCoroutine(LoadLevel("1st_floor"));
            }
            else if(actualScene.name.Equals("Bathroom_2nd") || actualScene.name.Equals("Adult_bedroom") || actualScene.name.Equals("Child_room"))
            {
                Debug.Log("Loading next scene: 2nd_floor");
                StartCoroutine(LoadLevel("2nd_floor"));
            }
            else
            {
                Debug.Log("Loading next scene: " + nextScene);
                StartCoroutine(LoadLevel(nextScene));
            }
        }
        else if(actualScene.name.Equals("1st_floor"))
        {
            Debug.Log("Loading next scene: " + nextScene);
            StartCoroutine(LoadLevel(nextScene));
        }
        else if(actualScene.name.Equals("2nd_floor"))
        {
            Debug.Log("Loading next scene: " + nextScene);
            StartCoroutine(LoadLevel(nextScene));
        }
    }
    
    public void LoadScene(string nextScene)
    {
        StartCoroutine(LoadLevel(nextScene));
    }
    
    IEnumerator LoadLevel(string sceneName)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);
        
        Debug.Log("Loading scene: " + sceneName);
        //Load scene
        SceneManager.LoadScene(sceneName);
    }

    private void animUpdate()
    {
        /*public static bool lightGarageState = false;
        public static bool lightFloor1State = false;
        public static bool lightBathFloor1State = false;
        public static bool lightOfficeState = false;
        public static bool lightBathFloor2State = false;
        public static bool lightChildRoomState = false;
        public static bool lightAdultRoomState = false;
        public static bool lightLaundryRoomState = false;*/

        switch (this.gameObject.scene.name)
        {
            case "1st_floor":
            {
                if (CoreMechanics.tvFloor1State)
                {
                    GameObject.Find("TvLight").GetComponent<Light>().enabled = true;
                }
                else
                {
                    GameObject.Find("TvLight").GetComponent<Light>().enabled = false;
                }

                if (CoreMechanics.dishwasherFloor1State)
                {
                    GameObject.Find("DishwasherLight").GetComponent<Light>().enabled = true;
                }
                else
                {
                    GameObject.Find("DishwasherLight").GetComponent<Light>().enabled = false;
                }

                if (CoreMechanics.ovenFloor1State)
                {
                    GameObject.Find("OvenLight").GetComponent<Light>().enabled = true;
                }
                else
                {
                    GameObject.Find("OvenLight").GetComponent<Light>().enabled = false;
                }
                
                if (CoreMechanics.lavaboFloor1State)
                {
                    GameObject.Find("LavaboOn").GetComponent<Renderer>().enabled = true;
                }
                else
                {
                    GameObject.Find("LavaboOn").GetComponent<Renderer>().enabled = false;
                }
                
                if (CoreMechanics.lightFloor1State)
                {
                    GameObject.Find("InterruptorLight1").GetComponent<Light>().enabled = true;
                    GameObject.Find("InterruptorLight2").GetComponent<Light>().enabled = true;
                    
                }
                else
                {
                    GameObject.Find("InterruptorLight1").GetComponent<Light>().enabled = false;
                    GameObject.Find("InterruptorLight2").GetComponent<Light>().enabled = false;
                }
                
                if (CoreMechanics.fridgeFloor1State)
                {
                    GameObject.Find("FridgeLight").GetComponent<Light>().enabled = true;
                }
                else
                {
                    GameObject.Find("FridgeLight").GetComponent<Light>().enabled = false;
                }
            }
            break;
        }
    }
}
