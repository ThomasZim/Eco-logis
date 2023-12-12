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
            case "Computer":
            {
                if (collision)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log(CoreMechanics.computerState);
                        if (CoreMechanics.computerState == false)
                        {
                            SceneManager.LoadScene("Computer_menu");
                            CoreMechanics.computerState = true;
                        }
                        else
                        {
                            CoreMechanics.computerState = false;
                        }
                    }

                    if (CoreMechanics.computerState)
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
        }
    }
        
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == character)
        {
            collision = true;
            if (CoreMechanics.computerState)
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
