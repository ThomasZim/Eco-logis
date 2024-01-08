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
    public Image BathOff;
    public Image BathOn;
    public Image DishWasher_a_off;
    public Image DishWasher_a_on;
    public Image DishWasher_b_off;
    public Image DishWasher_b_on;
    public Image DishWasher_c_off;
    public Image DishWasher_c_on;
    public Image DishWasher_d_off;
    public Image DishWasher_d_on;
    public Image oven_a_off;
    public Image oven_a_on;
    public Image oven_b_off;
    public Image oven_b_on;
    public Image oven_c_off;
    public Image oven_c_on;
    public Image shower_off;
    public Image shower_on;
    public Image toilet_off;
    public Image toilet_on;
    public Image washMach_a_off;
    public Image washMach_a_on;
    public Image washMach_b_off;
    public Image washMach_b_on;
    public Image washMach_c_off;
    public Image washMach_c_on;
    public Image heat_pump_off;
    public Image heat_pump_on;
    public Image natural_gaz_off;
    public Image natural_gaz_on;
    public Image oil_heating_off;
    public Image oil_heating_on;
    public Image kettel_off;
    public Image kettel_on;

    


    // Start is called before the first frame update
    public void hideAll()
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
        BathOff.enabled  = false;
        BathOn.enabled  = false;
        DishWasher_a_off.enabled  = false;
        DishWasher_a_on.enabled  = false;
        DishWasher_b_off.enabled  = false;
        DishWasher_b_on.enabled  = false;
        DishWasher_c_off.enabled  = false;
        DishWasher_c_on.enabled  = false;
        DishWasher_d_off.enabled  = false;
        DishWasher_d_on.enabled  = false;
        oven_a_off.enabled  = false;
        oven_a_on.enabled  = false;
        oven_b_off.enabled  = false;
        oven_b_on.enabled  = false;
        oven_c_off.enabled  = false;
        oven_c_on.enabled  = false;
        shower_off.enabled  = false;
        shower_on.enabled  = false;
        toilet_off.enabled  = false;
        toilet_on.enabled  = false;
        washMach_a_off.enabled  = false;
        washMach_a_on.enabled  = false;
        washMach_b_off.enabled  = false;
        washMach_b_on.enabled  = false;
        washMach_c_off.enabled  = false;
        washMach_c_on.enabled  = false; 
        heat_pump_off.enabled= false;
        heat_pump_on.enabled= false;
        natural_gaz_off.enabled= false;
        natural_gaz_on.enabled= false;
        oil_heating_off.enabled= false;
        oil_heating_on.enabled= false;
        kettel_off.enabled= false;
        kettel_on.enabled= false;
    }

    // Update is called once per frame
    public void activateOne(string img)
    {
        switch(img)
            {
                case "computerOff":
                    Debug.Log("VALERIE: computerOff");
                    computerOff.enabled  = true;
                    break;
                case "computerOn":
                    Debug.Log("VALERIE: computerOn");
                    computerOn.enabled  = true;
                    break;
                case "AirCondAOff":
                    Debug.Log("VALERIE: AirCondAOff");
                    AirCondAOff.enabled  = true;
                    break;
                case "AirCondAOn":
                    Debug.Log("VALERIE: AirCondAOn");
                    AirCondAOn.enabled  = true;
                    break;
                case "AirCondBOff":
                    Debug.Log("VALERIE: AirCondBOff");
                    AirCondBOff.enabled  = true;
                    break;
                case "AirCondBOn":
                    Debug.Log("VALERIE: AirCondBOn");
                    AirCondBOn.enabled  = true;
                    break;
                case "AirCondCOn":
                    Debug.Log("VALERIE: AirCondCOn");
                    AirCondCOn.enabled  = true;
                    break;
                case "AirCondCOff":
                    Debug.Log("VALERIE: AirCondCOff");
                    AirCondCOff.enabled  = true;
                    break;
                case "BulbAOff":
                    Debug.Log("VALERIE: BulbAOff");
                    BulbAOff.enabled  = true;
                    break;
                case "BulbAOn":
                    Debug.Log("VALERIE: BulbAOn");
                    BulbAOn.enabled  = true;
                    break;
                case "BulbBOff":
                    Debug.Log("VALERIE: BulbBOff");
                    BulbBOff.enabled  = true;
                    break;
                case "BulbBOn":
                    Debug.Log("VALERIE: BulbBOn");
                    BulbBOn.enabled  = true;
                    break;
                case "BulbCOff":
                    Debug.Log("VALERIE: BulbCOff");
                    BulbCOff.enabled  = true;
                    break;
                case "BulbCOn":
                    Debug.Log("VALERIE: BulbCOn");
                    BulbCOn.enabled  = true;
                    break;
                case "fridgeCOff":
                    Debug.Log("VALERIE: fridgeCOff");
                    fridgeCOff.enabled  = true;
                    break;
                case "fridgeCOn":
                    Debug.Log("VALERIE: fridgeCOn");
                    fridgeCOn.enabled  = true;
                    break;
                case "fridgeDOff":
                    Debug.Log("VALERIE: fridgeDOff");
                    fridgeDOff.enabled  = true;
                    break;
                case "fridgeDOn":
                    Debug.Log("VALERIE: fridgeDOn");
                    fridgeDOn.enabled  = true;
                    break;
                case "fridgeEOff":
                    Debug.Log("VALERIE: fridgeEOff");
                    fridgeEOff.enabled  = true;
                    break;
                case "fridgeEOn":
                    Debug.Log("VALERIE: fridgeEOn");
                    fridgeEOn.enabled  = true;
                    break;
                case "fridgeFOff":
                    fridgeFOff.enabled  = true;
                    break;
                case "fridgeFOn":
                    fridgeFOn.enabled  = true;
                    break;
                case "TVDOff":
                    Debug.Log("VALERIE: TVDOff");
                    TVDOff.enabled  = true;
                    break;
                case "TVDOn":
                    Debug.Log("VALERIE: TVDOn");
                    TVDOn.enabled  = true;
                    break;
                case "TVEOff":
                    Debug.Log("VALERIE: TVEOff");
                    TVEOff.enabled  = true;
                    break;
                case "TVEOn":
                    Debug.Log("VALERIE: TVEOn");
                    TVEOn.enabled  = true;
                    break;
                case "TVFOff":
                    Debug.Log("VALERIE: TVFOff");
                    TVFOff.enabled  = true;
                    break;
                case "TVFOn":
                    Debug.Log("VALERIE: TVFOn");
                    TVFOn.enabled  = true;
                    break;
                case "TVGOff":
                    TVGOff.enabled  = true;
                    break;
                case "BathOff":
                    Debug.Log("VALERIE: BathOff");
                    BathOff.enabled  = true;
                    break;
                case "BathOn":
                    Debug.Log("VALERIE: BathOn");
                    BathOn.enabled  = true;
                    break;
                case "DishWasher_a_off":
                    Debug.Log("VALERIE: DishWasher_a_off");
                    DishWasher_a_off.enabled  = true;
                    break;
                case "DishWasher_a_on":
                    Debug.Log("VALERIE: DishWasher_a_on");
                    DishWasher_a_on.enabled  = true;
                    break;
                case "DishWasher_b_off":
                    Debug.Log("VALERIE: DishWasher_b_off");
                    DishWasher_b_off.enabled  = true;
                    break;
                case "DishWasher_b_on":
                    Debug.Log("VALERIE: DishWasher_b_on");
                    DishWasher_b_on.enabled  = true;
                    break;
                case "DishWasher_c_off":
                    Debug.Log("VALERIE: DishWasher_c_off");
                    DishWasher_c_off.enabled  = true;
                    break;
                case "DishWasher_c_on":
                    Debug.Log("VALERIE: DishWasher_c_on");
                    DishWasher_c_on.enabled  = true;
                    break;
                 case "DishWasher_d_off":
                    DishWasher_d_off.enabled  = true;
                    break; 
                case "DishWasher_d_on":
                    DishWasher_d_on.enabled  = true;
                    break; 
                case "oven_a_off":
                    Debug.Log("VALERIE: oven_a_off");
                    oven_a_off.enabled  = true;
                    break;
                case "oven_a_on":
                    Debug.Log("VALERIE: oven_a_on");
                    oven_a_on.enabled  = true;
                    break;
                case "oven_b_off":
                    Debug.Log("VALERIE: oven_b_off");
                    oven_b_off.enabled  = true;
                    break;
                case "oven_b_on":
                    Debug.Log("VALERIE: oven_b_on");
                    oven_b_on.enabled  = true;
                    break;
                 case "oven_c_off":
                     Debug.Log("VALERIE: oven_c_off");
                    oven_c_off.enabled  = true;
                    break; 
                case "oven_c_on":
                    Debug.Log("VALERIE: oven_c_on");
                    oven_c_on.enabled  = true;
                    break;
                case "shower_off":
                    shower_off.enabled  = true;
                    break;
                case "shower_on":
                    shower_on.enabled  = true;
                    break;
                 case "toilet_off":
                     Debug.Log("VALERIE: toilet_off");
                     toilet_off.enabled  = true;
                    break; 
                case "toilet_on":
                    Debug.Log("VALERIE: toilet_on");
                    toilet_on.enabled  = true;
                    break;
                case "washMach_a_off":
                    Debug.Log("VALERIE: washMach_a_off");
                    washMach_a_off.enabled  = true;
                    break; 
                case "washMach_a_on":
                    Debug.Log("VALERIE: washMach_a_on");
                    washMach_a_on.enabled  = true;
                    break;
                case "washMach_b_off":
                    Debug.Log("VALERIE: washMach_b_off");
                    washMach_b_off.enabled  = true;
                    break;
                case "washMach_b_on":
                    Debug.Log("VALERIE: washMach_b_on");
                    washMach_b_on.enabled  = true;
                    break;
                 case "washMach_c_off":
                    Debug.Log("VALERIE: washMach_c_off");
                    washMach_c_off.enabled  = true;
                    break; 
                case "washMach_c_on":
                    Debug.Log("VALERIE: washMach_c_on");
                    washMach_c_on.enabled  = true;
                    break;
                case "heat_pump_off":
                     Debug.Log("VALERIE: heat_pump_off");
                     heat_pump_off.enabled  = true;
                    break; 
                case "heat_pump_on":
                    Debug.Log("VALERIE: heat_pump_on");
                    heat_pump_on.enabled  = true;
                    break;
                case "natural_gaz_off":
                    Debug.Log("VALERIE: natural_gaz_off");
                    natural_gaz_off.enabled  = true;
                    break; 
                case "natural_gaz_on":
                    Debug.Log("VALERIE: natural_gaz_on");
                    natural_gaz_on.enabled  = true;
                    break;
                case "oil_heating_off":
                    Debug.Log("VALERIE: oil_heating_off");
                    oil_heating_off.enabled  = true;
                    break;
                case "oil_heating_on":
                    Debug.Log("VALERIE: oil_heating_on");
                    oil_heating_on.enabled  = true;
                    break;
                 case "kettel_off":
                    Debug.Log("VALERIE: kettel_off");
                    kettel_off.enabled  = true;
                    break; 
                case "kettel_on":
                    Debug.Log("VALERIE: kettel_on");
                    kettel_on.enabled  = true;
                    break;
                                 
            }         
    }      
}
