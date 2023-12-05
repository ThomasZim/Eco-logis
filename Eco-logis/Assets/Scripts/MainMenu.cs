using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private LevelLoader levelLoader;
    void Start()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void quitMenu()
    {
        SceneManager.LoadScene("Office");
        StaticSceneTransi.PreviousSceneName = "Computer_menu";
    }
}
