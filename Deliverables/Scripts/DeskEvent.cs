using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskEvent : MonoBehaviour
{
    private GameObject[] infoDesks;
    
    // Start is called before the first frame update
    void Start()
    {
        infoDesks = GameObject.FindGameObjectsWithTag("InfoDesk");
        foreach (GameObject infoDesk in infoDesks)
        {
            infoDesk.GetComponent<Image>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player entered the Desk");
            // Find the gameobject with the name "InfoDesk" and set them to active
            foreach (GameObject infoDesk in infoDesks)
            {
                infoDesk.GetComponent<Image>().enabled = true;
                Debug.Log(infoDesk.name);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Player left the Desk");
            // Find the gameobject with the name "InfoDesk" and set them to active
            foreach (GameObject infoDesk in infoDesks)
            {
                infoDesk.GetComponent<Image>().enabled = false;
                Debug.Log(infoDesk.name);
            }
        }
    }
}
