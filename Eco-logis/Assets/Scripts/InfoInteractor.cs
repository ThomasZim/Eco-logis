using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoInteractor : MonoBehaviour
{
    public Image InfoOn;
    public Image InfoOff;
    public GameObject character;
    public string interactionCode;
    private LevelLoader levelLoader;
    
    // Start is called before the first frame update
    void Start()
    {
        InfoOn.enabled = false;
        InfoOff.enabled = false;
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == character)
        {
            //TODO: ADD ON/OFF LOGIC
            InfoOn.enabled = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == character)
        {
            //TODO: ADD ON/OFF LOGIC
            InfoOn.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == character)
        {
            if (Input.GetKey(KeyCode.E))
            {
                switch (interactionCode) {
                    case "Computer": {
                        SceneManager.LoadScene("Computer_menu");
                    }
                    break;
                }
            }
        }
    }
}
