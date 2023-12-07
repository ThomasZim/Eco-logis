using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComputerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
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
