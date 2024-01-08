using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class InfoInteractor : MonoBehaviour
{
    public GameObject character;
    public string interactionCode;
    private LevelLoader levelLoader;
    private ChangeInfoBulle bulleInteractor;
    private int internalCollisionCount = 0;
    
    



    // Start is called before the first frame update
    void Start()
    {
        //InfoTurnOn.enabled = false;
        //InfoTurnOff.enabled = false;
        internalCollisionCount = 0;
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        bulleInteractor = GameObject.Find("IPad").GetComponent<ChangeInfoBulle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCharacterColliding())
        {
            switch (interactionCode)
            {
                case "computer":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log(CoreMechanics.computerOfficeState);
                        if (CoreMechanics.computerOfficeState == false)
                        {
                            SceneManager.LoadScene("Computer_menu");
                            CoreMechanics.computerOfficeState = true;
                        }
                        else
                        {
                            CoreMechanics.computerOfficeState = false;
                        }
                    }
                    if (CoreMechanics.computerOfficeState == true)
                    {
                        Debug.Log("COLISION, COMPUTER IS ON");
                        bulleInteractor.hideAll();
                        bulleInteractor.activateOne("computerOff");
                    }
                    else
                    {
                        Debug.Log("COLISION, COMPUTER IS OFF");
                        bulleInteractor.hideAll();
                        bulleInteractor.activateOne("computerOn");
                    }
                }
                break;
                case "oven":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.ovenFloor1State == false)
                        {
                            CoreMechanics.ovenFloor1State = true;
                            CoreMechanics.CoreMecanicsEvent("Eating");
                        }
                        else
                        {
                            CoreMechanics.ovenFloor1State = false;
                        }
                    }
                    if (CoreMechanics.ovenFloor1State == true)
                    {
                        Debug.Log("COLISION, OVEN IS ON");
                        bulleInteractor.hideAll();
                        activateOven(false);
                    }
                    else
                    {
                        Debug.Log("COLISION, OVEN IS OFF");
                        bulleInteractor.hideAll();
                        activateOven(true);
                    }
                    
                }
                break;
                case "dishwasher":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.dishwasherFloor1State == false)
                        {
                            CoreMechanics.dishwasherFloor1State = true;
                            CoreMechanics.CoreMecanicsEvent("Dishwasher");
                        }
                        else
                        {
                            CoreMechanics.dishwasherFloor1State = false;
                        }
                    }
                    if (CoreMechanics.dishwasherFloor1State == true)
                    {
                        Debug.Log("COLISION, DISHWASHER IS ON");
                        bulleInteractor.hideAll();
                        activateDishwasher(false);
                    }
                    else
                    {
                        Debug.Log("COLISION, DISHWASHER IS OFF");
                        bulleInteractor.hideAll();
                        activateDishwasher(true);
                    }
                }
                break;
                case "fridge":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.fridgeFloor1State == false)
                        {
                            CoreMechanics.fridgeFloor1State = true;
                        }
                        else
                        {
                            CoreMechanics.fridgeFloor1State = false;
                        }
                    }
                    if (CoreMechanics.fridgeFloor1State == true)
                    {
                        Debug.Log("COLISION, FRIDGE IS ON");
                        bulleInteractor.hideAll();
                        activateFridge(false);
                    }
                    else
                    {
                        Debug.Log("COLISION, FRIDGE IS OFF");
                        bulleInteractor.hideAll();
                        activateFridge(true);
                    }
                }
                break;
                case "interruptor":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        switch (this.gameObject.scene.name)
                        {
                            case "1st_floor":
                            {
                                if (CoreMechanics.lightFloor1State == false)
                                {
                                    CoreMechanics.lightFloor1State = true;
                                }
                                else
                                {
                                    CoreMechanics.lightFloor1State = false;
                                }
                            }
                                break;
                            case "Garage":
                            {
                                if (CoreMechanics.lightGarageState == false)
                                {
                                    CoreMechanics.lightGarageState = true;
                                }
                                else
                                {
                                    CoreMechanics.lightGarageState = false;
                                }
                            }
                                break;
                            case "buanderie_chauffage":
                            {
                                if (CoreMechanics.lightLaundryRoomState == false)
                                {
                                    CoreMechanics.lightLaundryRoomState = true;
                                }
                                else
                                {
                                    CoreMechanics.lightLaundryRoomState = false;
                                }
                            }
                                break;
                            case "Bathroom_1st":
                            {
                                if (CoreMechanics.lightBathFloor1State == false)
                                {
                                    CoreMechanics.lightBathFloor1State = true;
                                }
                                else
                                {
                                    CoreMechanics.lightBathFloor1State = false;
                                }
                            }
                                break;
                            case "Office":
                            {
                                if (CoreMechanics.lightOfficeState == false)
                                {
                                    CoreMechanics.lightOfficeState = true;
                                }
                                else
                                {
                                    CoreMechanics.lightOfficeState = false;
                                }
                            }
                                break;
                            case "2nd_floor":
                            {
                                if (CoreMechanics.lightFloor2State == false)
                                {
                                    CoreMechanics.lightFloor2State = true;
                                }
                                else
                                {
                                    CoreMechanics.lightFloor2State = false;
                                }
                            }
                                break;
                            case "Child_room":
                            {
                                if (CoreMechanics.lightChildRoomState == false)
                                {
                                    CoreMechanics.lightChildRoomState = true;
                                }
                                else
                                {
                                    CoreMechanics.lightChildRoomState = false;
                                }
                            }
                            break;
                            case "Adult_bedroom":
                            {
                                if (CoreMechanics.lightAdultRoomState == false)
                                {
                                    CoreMechanics.lightAdultRoomState = true;
                                }
                                else
                                {
                                    CoreMechanics.lightAdultRoomState = false;
                                }
                            }
                            break;
                            case "Bathroom_2nd":
                            {
                                if (CoreMechanics.lightBathFloor2State == false)
                                {
                                    CoreMechanics.lightBathFloor2State = true;
                                }
                                else
                                {
                                    CoreMechanics.lightBathFloor2State = false;
                                }
                            }
                            break;
                        }
                    }

                    switch (this.gameObject.scene.name)
                    {
                        case "1st_floor":
                        {
                            if (CoreMechanics.lightFloor1State)
                            {
                                Debug.Log("COLISION, LIGHT 1ST_FLOOR IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT 1ST_FLOOR IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                        break;
                        case "Garage":
                        {
                            if (CoreMechanics.lightGarageState)
                            {
                                Debug.Log("COLISION, LIGHT GARAGE IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT GARAGE IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                            break;
                        case "buanderie_chauffage":
                        {
                            if(CoreMechanics.lightLaundryRoomState)
                            {
                                Debug.Log("COLISION, LIGHT LAUNDRY ROOM IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT LAUNDRY ROOM IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                            break;
                        case "Bathroom_1st":
                        {
                            if (CoreMechanics.lightBathFloor1State)
                            {
                                Debug.Log("COLISION, LIGHT BATHROOM 1ST FLOOR IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT BATHROOM 1ST FLOOR IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                        break;
                        case "Office":
                        {
                            if (CoreMechanics.lightOfficeState)
                            {
                                Debug.Log("COLISION, LIGHT OFFICE IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT OFFICE IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                        break;
                        case "2nd_floor":
                        {
                            if (CoreMechanics.lightFloor2State)
                            {
                                Debug.Log("COLISION, LIGHT SECOND FLOOR IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT SECOND FLOOR IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                            break;
                        case "Child_room":
                        {
                            if (CoreMechanics.lightChildRoomState)
                            {
                                Debug.Log("COLISION, LIGHT CHILD ROOM IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT CHILD ROOM IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                        break;
                        case "Adult_bedroom":
                        {
                            if (CoreMechanics.lightAdultRoomState)
                            {
                                Debug.Log("COLISION, LIGHT ADULT ROOM IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT ADULT ROOM IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                        break;
                        case "Bathroom_2nd":
                        {
                            if (CoreMechanics.lightBathFloor2State)
                            {
                                Debug.Log("COLISION, LIGHT BATHROOM 2ND IS ON");
                                bulleInteractor.hideAll();
                                activateBulb(false);
                            }
                            else
                            {
                                Debug.Log("COLISION, LIGHT BATHROOM 2ND IS OFF");
                                bulleInteractor.hideAll();
                                activateBulb(true);
                            }
                        }
                        break;
                    }
                }
                break;
                case "tv_1stfloor":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.tvFloor1State == false)
                        {
                            CoreMechanics.tvFloor1State = true;
                            CoreMechanics.CoreMecanicsEvent("TV");
                        }
                        else
                        {
                            CoreMechanics.tvFloor1State = false;
                        }
                    }

                    if (CoreMechanics.tvFloor1State)
                    {
                        bulleInteractor.hideAll();
                        activateTV(false);
                    }
                    else
                    {
                        bulleInteractor.hideAll();
                        activateTV(true);
                    }
                }
                break;
                case "lavabo":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        switch (this.gameObject.scene.name)
                        {
                            case "1st_floor":
                            {
                                if (CoreMechanics.lavaboFloor1State == false)
                                {
                                    CoreMechanics.lavaboFloor1State = true;
                                    CoreMechanics.CoreMecanicsEvent("Drinking");
                                }
                                else
                                {
                                    CoreMechanics.lavaboFloor1State = false;
                                }
                            }
                                break;
                            case "Bathroom_1st":
                            {
                                if (CoreMechanics.lavaboBathFloor1State == false)
                                {
                                    CoreMechanics.lavaboBathFloor1State = true;
                                    CoreMechanics.CoreMecanicsEvent("Lavabo");
                                }
                                else
                                {
                                    CoreMechanics.lavaboBathFloor1State = false;
                                }
                            }
                                break;
                            case "Bathroom_2nd":
                            {
                                if (CoreMechanics.lavaboBathFloor2State == false)
                                {
                                    CoreMechanics.lavaboBathFloor2State = true;
                                    CoreMechanics.CoreMecanicsEvent("Lavabo");
                                }
                                else
                                {
                                    CoreMechanics.lavaboBathFloor2State = false;
                                }
                            }
                                break;
                        }
                    }
                }
                break;
                case "washmachine":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.washMachineLaundryRoomState == false)
                        {
                            CoreMechanics.washMachineLaundryRoomState = true;
                            CoreMechanics.CoreMecanicsEvent("WashMachine");
                        }
                        else
                        {
                            CoreMechanics.washMachineLaundryRoomState = false;
                        }
                    }

                    if (CoreMechanics.washMachineLaundryRoomState)
                    {
                        bulleInteractor.hideAll();
                        activateWashMachine(false);
                    }
                    else
                    {
                        bulleInteractor.hideAll();
                        activateWashMachine(true);
                    }
                }
                break;
                case "heating_pump":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.heaterLaundryRoomState == false)
                        {
                            CoreMechanics.heaterLaundryRoomState = true;
                            CoreMechanics.CoreMecanicsEvent("HeaterON");
                        }
                        else
                        {
                            CoreMechanics.heaterLaundryRoomState = false;
                            CoreMechanics.CoreMecanicsEvent("HeaterOff");
                        }
                    }
                    
                    if (CoreMechanics.heaterLaundryRoomState)
                    {
                        bulleInteractor.hideAll();
                        activateHeater(false);
                    }
                    else
                    {
                        bulleInteractor.hideAll();
                        activateHeater(true);
                    }
                }
                break;
                case "bath":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.bathBathFloor2State == false)
                        {
                            CoreMechanics.bathBathFloor2State = true;
                            CoreMechanics.CoreMecanicsEvent("Bath");
                        }
                        else
                        {
                            CoreMechanics.bathBathFloor2State = false;
                        }
                    }
                    if (CoreMechanics.bathBathFloor2State)
                    {
                        bulleInteractor.hideAll();
                        bulleInteractor.activateOne("BathOff");
                    }
                    else
                    {
                        bulleInteractor.hideAll();
                        bulleInteractor.activateOne("BathOn");
                    }
                }
                break;
                case "wc":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        switch (this.gameObject.scene.name)
                        {
                            case "Bathroom_1st":
                            {
                                if (CoreMechanics.wcBathFloor1State == false)
                                {
                                    CoreMechanics.wcBathFloor1State = true;
                                    CoreMechanics.CoreMecanicsEvent("WC");
                                }
                                else
                                {
                                    CoreMechanics.wcBathFloor1State = false;
                                }
                            }
                                break;
                            case "Bathroom_2nd":
                            {
                                if (CoreMechanics.wcBathFloor2State == false)
                                {
                                    CoreMechanics.wcBathFloor2State = true;
                                    CoreMechanics.CoreMecanicsEvent("WC");
                                }
                                else
                                {
                                    CoreMechanics.wcBathFloor2State = false;
                                }
                            }
                                break;
                        }
                    }
                    switch (this.gameObject.scene.name)
                    {
                        case "Bathroom_1st":
                        {
                            if (CoreMechanics.wcBathFloor1State)
                            {
                                bulleInteractor.hideAll();
                                bulleInteractor.activateOne("toilet_off");
                            }
                            else
                            {
                                bulleInteractor.hideAll();
                                bulleInteractor.activateOne("toilet_on");
                            }
                        }
                            break;
                        case "Bathroom_2nd":
                        {
                            if (CoreMechanics.wcBathFloor2State)
                            {
                                bulleInteractor.hideAll();
                                bulleInteractor.activateOne("toilet_off");
                            }
                            else
                            {
                                bulleInteractor.hideAll();
                                bulleInteractor.activateOne("toilet_on");
                            }
                        }
                        break;
                    }
                }
                break;
                case "conditioner":
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.conditionerLaundryRoomState == false)
                        {
                            CoreMechanics.conditionerLaundryRoomState = true;
                            CoreMechanics.CoreMecanicsEvent("ConditionerON");
                        }
                        else
                        {
                            CoreMechanics.conditionerLaundryRoomState = false;
                            CoreMechanics.CoreMecanicsEvent("ConditionerOff");
                        }
                    }

                    if (CoreMechanics.conditionerLaundryRoomState)
                    {
                        bulleInteractor.hideAll();
                        activateConditioner(false);
                    }
                    else
                    {
                        bulleInteractor.hideAll();
                        activateConditioner(true);
                    }
                }
                break;
            }
        }
        else if (!StaticInteractorUtils.IsCharacterColliding())
        {
            Debug.Log("I AM: " + interactionCode + "NO COLISION, HIDE ALL");
            bulleInteractor.hideAll();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == character)
        {
            internalCollisionCount++;
            StaticInteractorUtils.collisionCount++;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == character)
        {
            internalCollisionCount--;
            StaticInteractorUtils.collisionCount--;
            internalCollisionCount = Mathf.Max(0,  internalCollisionCount);
            StaticInteractorUtils.collisionCount = Mathf.Max(0,  StaticInteractorUtils.collisionCount);
        }
    }
    
    private bool IsCharacterColliding()
    {
        Debug.Log("COLISION COUNT: " + internalCollisionCount);
        return internalCollisionCount > 0;
    }

    private void activateBulb(bool state)
    {
        switch (CoreMechanics.lightLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("BulbCOn");
                }
                else
                {
                    bulleInteractor.activateOne("BulbCOff");
                }
            }
                break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("BulbBOn");
                }
                else
                {
                    bulleInteractor.activateOne("BulbBOff");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("BulbAOn");
                }
                else
                {
                    bulleInteractor.activateOne("BulbAOff");
                }
            }
                break;
        }
    }
    
    private void activateOven(bool state)
    {
        switch (CoreMechanics.ovenLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("oven_c_on");
                }
                else
                {
                    bulleInteractor.activateOne("oven_c_off");
                }
            }
            break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("oven_b_on");
                }
                else
                {
                    bulleInteractor.activateOne("oven_b_off");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("oven_a_on");
                }
                else
                {
                    bulleInteractor.activateOne("oven_a_off");
                }
            }
            break;
        }
    }

    private void activateDishwasher(bool state)
    {
        switch (CoreMechanics.dishwasherLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("DishWasher_c_off");
                }
                else
                {
                    bulleInteractor.activateOne("DishWasher_c_on");
                }
            }
                break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("DishWasher_b_off");
                }
                else
                {
                    bulleInteractor.activateOne("DishWasher_b_on");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("DishWasher_a_off");
                }
                else
                {
                    bulleInteractor.activateOne("DishWasher_a_on");
                }
            }
            break;
        }
    }

    private void activateFridge(bool state)
    {
        switch (CoreMechanics.fridgeLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("fridgeEOn");
                }
                else
                {
                    bulleInteractor.activateOne("fridgeEOff");
                }
            }
            break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("fridgeDOn");
                }
                else
                {
                    bulleInteractor.activateOne("fridgeDOff");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("fridgeCOn");
                }
                else
                {
                    bulleInteractor.activateOne("fridgeCOff");
                }
            }
            break;
        }
    }
    
    private void activateTV(bool state)
    {
        if (state)
        {
            bulleInteractor.activateOne("TVFOn");
        }
        else
        {
            bulleInteractor.activateOne("TVFOff");  
        }
            
    }
    
    private void activateWashMachine(bool state)
    {
        switch (CoreMechanics.washMachineLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("washMach_c_on");
                }
                else
                {
                    bulleInteractor.activateOne("washMach_c_off");
                }
            }
                break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("washMach_b_on");
                }
                else
                {
                    bulleInteractor.activateOne("washMach_b_off");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("washMach_a_on");
                }
                else
                {
                    bulleInteractor.activateOne("washMach_a_off");
                }
            }
                break;
        }

    }
    
    private void activateHeater(bool state)
    {
        // HEATER PNG DOES NOT EXIST, FUNCTION CALLS ARE USELESS
        switch (CoreMechanics.heaterLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("heater_c_on");
                }
                else
                {
                    bulleInteractor.activateOne("heater_c_off");
                }
            }
                break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("heater_b_on");
                }
                else
                {
                    bulleInteractor.activateOne("heater_b_off");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("heater_a_on");
                }
                else
                {
                    bulleInteractor.activateOne("heater_a_off");
                }
            }
                break;
        }
    }

    private void activateConditioner(bool state)
    {
        switch (CoreMechanics.conditionerLevel)
        {
            case 0:
            {
                if (state)
                {
                    bulleInteractor.activateOne("AirCondCOff");
                }
                else
                {
                    bulleInteractor.activateOne("AirCondCOn");
                }
            }
                break;
            case 1:
            {
                if (state)
                {
                    bulleInteractor.activateOne("AirCondBOff");
                }
                else
                {
                    bulleInteractor.activateOne("AirCondBOn");
                }
            }
                break;
            case 2:
            {
                if (state)
                {
                    bulleInteractor.activateOne("AirCondAOff");
                }
                else
                {
                    bulleInteractor.activateOne("AirCondAOn");
                }
            }
                break;
        }
    }


}
