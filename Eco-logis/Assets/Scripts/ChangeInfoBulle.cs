using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeInfoBulle : MonoBehaviour
{
    public Image computerOff;
    public Image computerOn;
    public Image AirCondAOff;
    public Image AirCondAOn;
    public Image AirCondBOff;
    public Image AirCondBOn;
    public Image AirCondCOff;
    public Image AirCondCOn;
    public Image BulbAOff;
    public Image BulbAOn;
    public Image BulbBOff;
    public Image BulbBOn;
    public Image BulbCOff;
    public Image BulbCOn;
    public Image fridgeCOff;
    public Image fridgeCOn;
    public Image fridgeDOff;
    public Image fridgeDOn;
    public Image fridgeEOff;
    public Image fridgeEOn;
    public Image fridgeFOff;
    public Image fridgeFOn;
    public Image TVDOff;
    public Image TVDOn;
    public Image TVEOff;
    public Image TVEOn;
    public Image TVFOff;
    public Image TVFOn;
    public Image TVGOff;
    public Image TVGOn;


    // Start is called before the first frame update
    void hideAll()
    {
        computerOff.enabled  = false;
        computerOn.enabled  = false;
        AirCondAOff.enabled  = false;
        AirCondAOn.enabled  = false;
        AirCondBOff.enabled  = false;
        AirCondBOn.enabled  = false;
        AirCondCOff.enabled  = false;
        AirCondCOn.enabled  = false;
        BulbAOff.enabled  = false;
        BulbAOn.enabled  = false;
        BulbBOff.enabled  = false;
        BulbBOn.enabled  = false;
        BulbCOff.enabled  = false;
        BulbCOn.enabled  = false;
        fridgeCOff.enabled  = false;
        fridgeCOn.enabled  = false;
        fridgeDOff.enabled  = false;
        fridgeDOn.enabled  = false;
        fridgeEOff.enabled  = false;
        fridgeEOn.enabled  = false;
        fridgeFOff.enabled  = false;
        fridgeFOn.enabled  = false;
        TVDOff.enabled  = false;
        TVDOn.enabled  = false;
        TVEOff.enabled  = false;
        TVEOn.enabled  = false;
        TVFOff.enabled  = false;
        TVFOn.enabled  = false;
        TVGOff.enabled  = false;
        TVGOn.enabled  = false; 
    }

    // Update is called once per frame
    void activateOne(string img)
    {
        switch(img)
            {
                case "computerOff":
                    computerOff.enabled  = true;
                    break;
                case "computerOn":
                    computerOn.enabled  = true;
                    break;
                case "AirCondAOff":
                    AirCondAOff.enabled  = true;
                    break;
                case "AirCondAOn":
                    AirCondAOn.enabled  = true;
                    break;
                case "AirCondBOff":
                    AirCondBOff.enabled  = true;
                    break;
                case "AirCondBOn":
                    AirCondBOn.enabled  = true;
                    break;
                case "AirCondCOn":
                    AirCondCOn.enabled  = true;
                    break;
                case "AirCondCOff":
                    AirCondCOff.enabled  = true;
                    break;
                case "BulbAOff":
                    BulbAOff.enabled  = true;
                    break;
                case "BulbAOn":
                    BulbAOn.enabled  = true;
                    break;
                case "BulbBOff":
                    BulbBOff.enabled  = true;
                    break;
                case "BulbBOn":
                    BulbBOn.enabled  = true;
                    break;
                case "BulbCOff":
                    BulbCOff.enabled  = true;
                    break;
                case "BulbCOn":
                    BulbCOn.enabled  = true;
                    break;
                case "fridgeCOff":
                    fridgeCOff.enabled  = true;
                    break;
                case "fridgeCOn":
                    fridgeCOn.enabled  = true;
                    break;
                case "fridgeDOff":
                    fridgeDOff.enabled  = true;
                    break;
                case "fridgeDOn":
                    fridgeDOn.enabled  = true;
                    break;
                case "fridgeEOff":
                    fridgeEOff.enabled  = true;
                    break;
                case "fridgeEOn":
                    fridgeEOn.enabled  = true;
                    break;
                case "fridgeFOff":
                    fridgeFOff.enabled  = true;
                    break;
                case "fridgeFOn":
                    fridgeFOn.enabled  = true;
                    break;
                case "TVDOff":
                    TVDOff.enabled  = true;
                    break;
                case "TVDOn":
                    TVDOn.enabled  = true;
                    break;
                case "TVEOff":
                    TVEOff.enabled  = true;
                    break;
                case "TVEOn":
                    TVEOn.enabled  = true;
                    break;
                case "TVFOff":
                    TVFOff.enabled  = true;
                    break;
                case "TVFOn":
                    TVFOn.enabled  = true;
                    break;
                case "TVGOff":
                    TVGOff.enabled  = true;
                    break;
                case "TVGOn":
                    TVGOn.enabled  = true;
                    break;
                
                
            }   
        
    }
}
