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
    private bool collision = false;

    // Start is called before the first frame update
    void Start()
    {
        //InfoTurnOn.enabled = false;
        //InfoTurnOff.enabled = false;
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (interactionCode)
        {
            case "computer":
            {
                if (collision)
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
                }
            } 
            break;
            case "oven":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.ovenFloor1State == false)
                        {
                            CoreMechanics.ovenFloor1State = true;
                        }
                        else
                        {
                            CoreMechanics.ovenFloor1State = false;
                        }
                    }
                }
            }
            break;
            case "dishwasher":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.dishwasherFloor1State == false)
                        {
                            CoreMechanics.dishwasherFloor1State = true;
                        }
                        else
                        {
                            CoreMechanics.dishwasherFloor1State = false;
                        }
                    }
                }
            }
            break;
            case "fridge":
            {
                if (collision)
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
                }
            }
            break;
            case "interruptor":
            {
                if (collision)
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
                }
            }
            break;
            case "tv_1stfloor":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.tvFloor1State == false)
                        {
                            CoreMechanics.tvFloor1State = true;
                        }
                        else
                        {
                            CoreMechanics.tvFloor1State = false;
                        }
                    }
                }
            }
            break;
            case "lavabo":
            {
                if (collision)
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
            }
            break;
            case "washmachine":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.washMachineLaundryRoomState == false)
                        {
                            CoreMechanics.washMachineLaundryRoomState = true;
                        }
                        else
                        {
                            CoreMechanics.washMachineLaundryRoomState = false;
                        }
                    }
                }
            }
            break;
            case "heating_pump":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.heaterLaundryRoomState == false)
                        {
                            CoreMechanics.heaterLaundryRoomState = true;
                        }
                        else
                        {
                            CoreMechanics.heaterLaundryRoomState = false;
                        }
                    }
                }
            }
            break;
            case "bath":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.bathBathFloor2State == false)
                        {
                            CoreMechanics.bathBathFloor2State = true;
                        }
                        else
                        {
                            CoreMechanics.bathBathFloor2State = false;
                        }
                    }
                }
            }
            break;
            case "wc":
            {
                if (collision)
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
                                }
                                else
                                {
                                    CoreMechanics.wcBathFloor2State = false;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            break;
            case "conditioner":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (CoreMechanics.conditionerLaundryRoomState == false)
                        {
                            CoreMechanics.conditionerLaundryRoomState = true;
                        }
                        else
                        {
                            CoreMechanics.conditionerLaundryRoomState = false;
                        }
                    }
                }
            }
            break;
        }
    }
        
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == character)
        {
            collision = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        collision = false;
    }
}
