using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoInteractor : MonoBehaviour
{
    public Image InfoTurnOn;
    public Image InfoTurnOff;
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

                    if (CoreMechanics.computerOfficeState)
                    {
                        InfoTurnOff.enabled = true;
                        InfoTurnOn.enabled = false;
                    }
                    else
                    {
                        InfoTurnOff.enabled = false;
                        InfoTurnOn.enabled = true;
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
                        Debug.Log("ovenFloor1State: " + CoreMechanics.ovenFloor1State);
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
                
                if (CoreMechanics.ovenFloor1State)
                {
                    InfoTurnOff.enabled = true;
                    InfoTurnOn.enabled = false;
                }
                else
                {
                    InfoTurnOff.enabled = false;
                    InfoTurnOn.enabled = true;
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
            if (CoreMechanics.computerOfficeState)
            {
                InfoTurnOff.enabled = true;
            }
            else
            {
                InfoTurnOn.enabled = true;
            }
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        collision = false;
        InfoTurnOff.enabled = false;
        InfoTurnOn.enabled = false;
    }
}
