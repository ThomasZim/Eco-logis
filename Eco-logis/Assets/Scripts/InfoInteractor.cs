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
                        if (CoreMechanics.lavaboFloor1State == false)
                        {
                            CoreMechanics.lavaboFloor1State = true;
                        }
                        else
                        {
                            CoreMechanics.lavaboFloor1State = false;
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
