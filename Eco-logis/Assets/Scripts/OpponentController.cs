using UnityEngine;
using System.Collections;
using System;

public class OpponentController : MonoBehaviour
{
    public Transform[] targetAreas; // Assign the four red square areas to this array
    public float moveSpeed = 0.2f;

    private Transform currentTarget;
    private bool playerInSight = false;

    void Start()
    {
        FindClosestTarget();
    }

    void Update()
    {
        if (playerInSight)
        {
            // Player has opponent in sight, don't allow the opponent to enter red squares
            // pattern of movement not causing troubles 
            SwitchTarget();
            return;
        }
        else{
            //pattern of movement causing troubles
            MoveToTarget();
        }

        
    }

   void MoveToTarget()
{
    if (currentTarget != null)
    {
        // Check if the opponent is inside a red square
        bool insideRedSquare = false;
        foreach (Transform target in targetAreas)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < 1.0f) // Adjust this distance as needed
            {
                insideRedSquare = true;
                break;
            }
        }

        if (!insideRedSquare)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // You can add some behavior here, such as stopping or changing direction
        }
    }
}


    void FindClosestTarget()
    {
        float shortestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (Transform target in targetAreas)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                closestTarget = target;
            }
        }

        currentTarget = closestTarget;
    }

    void SwitchTarget()
    {
        System.Random random = new System.Random();

        // Get a random index different from the current target
        int newIndex;
        do
        {
            newIndex = random.Next(targetAreas.Length);
        } while (targetAreas[newIndex] == currentTarget);

        // Update the current target
        currentTarget = targetAreas[newIndex];
    }



    // Called by PlayerController when the player has the opponent in vision
    public void SetPlayerInSight(bool inSight)
    {
        playerInSight = inSight;
    }
}
