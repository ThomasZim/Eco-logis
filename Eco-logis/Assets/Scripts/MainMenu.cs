using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _textEasy;
    [SerializeField] private GameObject _textNormal;
    [SerializeField] private GameObject _textHard;

    void Start()
    { 
        CoreMechanics.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CoreMechanics.gameLevel)
        {
            case 0:
                _textEasy.GetComponent<TMP_Text>().text = "[ EASY ]";
                _textNormal.GetComponent<TMP_Text>().text = "NORMAL";
                _textHard.GetComponent<TMP_Text>().text = "HARD";
            break;
            case 1:
                _textEasy.GetComponent<TMP_Text>().text = "EASY";
                _textNormal.GetComponent<TMP_Text>().text = "[ NORMAL ]";
                _textHard.GetComponent<TMP_Text>().text = "HARD";
            break;
            case 2:
                _textEasy.GetComponent<TMP_Text>().text = "EASY";
                _textNormal.GetComponent<TMP_Text>().text = "NORMAL";
                _textHard.GetComponent<TMP_Text>().text = "[ HARD ]";
                break;
        }
    }
    
    public void SetEasy()
    {
        CoreMechanics.gameLevel = 0;
    }
    
    public void SetNormal()
    {
        CoreMechanics.gameLevel = 1;
    }
    
    public void SetHard()
    {
        CoreMechanics.gameLevel = 2;
    }
    
    public void LaunchGame()
    {
        Debug.Log("Launching game");
        if (StaticSceneTransi.PreviousSceneName.Equals("null"))
        {
            SceneManager.LoadScene("1st_floor");
            switch (CoreMechanics.gameLevel)
            {
                case 0:
                    CoreMechanics.InitEasy();
                    break;
                case 1:
                    CoreMechanics.InitNormal();
                    break;
                case 2:
                    CoreMechanics.InitHard();
                    break;
            }
        }
        else
        {
            Debug.Log(StaticSceneTransi.PreviousSceneName);
            SceneManager.LoadScene(StaticSceneTransi.PreviousSceneName);
        }
        CoreMechanics.Start();
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
    
}
