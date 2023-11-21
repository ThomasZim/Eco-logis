using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kidBehaviour : MonoBehaviour
{
    public List<GameObject> wayPoints;
    public float speed = 2f;
    int index = 0;
    //bool notAtDestination = false;

    void Start()
    {
        
    }


    void Update()
    {
        Vector3 destination = wayPoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, wayPoints[index].transform.position, speed * Time.deltaTime);
        transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);
        if(distance <= 0.05f){
            ChangeIndex();
        }
        
    }

    

    // This function is called when a collision occurs.
    private void OnTriggerEnter(Collider other)
    {
        
        if (wayPoints.Contains(other.gameObject) == false)
        {
            //change index immediately if random object
            ChangeIndex();
            Debug.Log("Collision with: " + other.gameObject.name);
        }
        
    }

    private void ChangeIndex()
    {
        index = Random.Range(0, wayPoints.Count);
    }
}

