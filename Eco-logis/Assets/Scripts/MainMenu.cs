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

    public AudioSource audioSource;
    
    private bool startingNewGame = true;

    void Start()
    {
        if (StaticSceneTransi.PreviousSceneName.Equals("null"))
        {
            startingNewGame = true;
        }
        else
        {
            startingNewGame = false;
            Debug.Log("Not starting a new game");
            GameObject.Find("DiffEasyButton").SetActive(false);
            GameObject.Find("DiffNormalButton").SetActive(false);
            GameObject.Find("DiffHardButton").SetActive(false);
        }
        CoreMechanics.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (startingNewGame)
        {
            GameObject.Find("DiffEasyButton").SetActive(true);
            GameObject.Find("DiffNormalButton").SetActive(true);
            GameObject.Find("DiffHardButton").SetActive(true);
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
        if (startingNewGame)
        {
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
            startingNewGame = false;
            SceneManager.LoadScene("1st_floor");
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
    
    public void PlaySound()
    {
        Debug.Log("Playing sound on a different thread");
        StartCoroutine(PlaySoundCoroutine());
    }

    IEnumerator PlaySoundCoroutine()
    {
        audioSource.PlayScheduled(0);
        yield return null;
    }
    
    public void RestartGame()
    {
        StaticSceneTransi.PreviousSceneName = "null";
        SceneManager.LoadScene("Main_menu");
    }
    
}
