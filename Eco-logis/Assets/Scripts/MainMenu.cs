using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    { 
        CoreMechanics.stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LaunchGame()
    {
        Debug.Log("Launching game");
        if (StaticSceneTransi.PreviousSceneName.Equals("null"))
        {
            SceneManager.LoadScene("1st_floor");
        }
        else
        {
            Debug.Log(StaticSceneTransi.PreviousSceneName);
            SceneManager.LoadScene(StaticSceneTransi.PreviousSceneName);
        }
        CoreMechanics.start();
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    
}
