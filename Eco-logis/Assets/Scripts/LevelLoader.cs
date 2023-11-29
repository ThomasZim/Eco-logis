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
        // First floor
        if (SceneManager.GetActiveScene().name.Equals("1st_floor"))
        {
            Debug.Log("StaticSceneTransi.PreviousScene.name: " + StaticSceneTransi.PreviousSceneName);
            if (StaticSceneTransi.PreviousSceneName.Equals("Office"))
            {
                character.transform.position = new Vector3(1.174f, 0f, -1.132f);
                character.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
    public void LoadNextRoom(Scene actualScene, string nextScene)
    {
        if (!actualScene.name.Equals("1st_floor") && !actualScene.name.Equals("2nd_floor"))
        {
            if(actualScene.name.Equals("Bathroom_1st") || actualScene.name.Equals("Office") || actualScene.name.Equals("Garage"))
            {
                Debug.Log("Loading next scene: 1st_floor");
                StartCoroutine(LoadLevel("1st_floor"));
            }
        }
        else if (actualScene.name.Equals("1st_floor"))
        {
            Debug.Log("Loading next scene: " + nextScene);
            StartCoroutine(LoadLevel(nextScene));
        }
        
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
}
