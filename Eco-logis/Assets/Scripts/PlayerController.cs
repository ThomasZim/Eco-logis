using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fieldOfViewAngle = 90f; // Adjust as needed
    public float viewDistance = 100f; // Adjust as needed
    public float middleRayAngle = 10f; // Adjust as needed

    private LineRenderer lineRenderer;
    private bool opponentInSight;
    private bool opponentNotInSight;
    void Start()
    {
        // Create and configure the Line Renderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 6;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.green;

        // needed to check  
        opponentNotInSight = false;
    }

    void Update()
    {
        RotateFieldOfVision();

        // Initialize variables for ray directions
        Vector3 forwardDirection = transform.forward;
        Vector3 rightDirection = Quaternion.Euler(0, fieldOfViewAngle / 2f, 0) * forwardDirection; // half of fieldOfViewAngle to the right
        Vector3 leftDirection = Quaternion.Euler(0, -fieldOfViewAngle / 2f, 0) * forwardDirection; // half of fieldOfViewAngle to the left

        // Initialize RaycastHit variables
        RaycastHit hitForward;
        RaycastHit hitRight;
        RaycastHit hitLeft;

        bool raycastForward = Physics.Raycast(transform.position, forwardDirection, out hitForward, viewDistance);
        bool raycastRight = Physics.Raycast(transform.position, rightDirection, out hitRight, viewDistance);
        bool raycastLeft = Physics.Raycast(transform.position, leftDirection, out hitLeft, viewDistance);

        UpdateLineRenderer(forwardDirection, viewDistance, 0, 1, raycastForward, hitForward);
        UpdateLineRenderer(rightDirection, viewDistance, 2, 3, raycastRight, hitRight);
        UpdateLineRenderer(leftDirection, viewDistance, 4, 5, raycastLeft, hitLeft);

        HandleOpponentSight(hitForward, hitRight, hitLeft);

        // Visualize the raycasts in the Unity Editor
        Debug.DrawRay(transform.position, forwardDirection * viewDistance, Color.green);
        Debug.DrawRay(transform.position, rightDirection * viewDistance, Color.green);
        Debug.DrawRay(transform.position, leftDirection * viewDistance, Color.green);
    }

    void UpdateLineRenderer(Vector3 direction, float distance, int startIndex, int endIndex, bool hasHit, RaycastHit hitInfo)
    {
        lineRenderer.SetPosition(startIndex, transform.position);
        lineRenderer.SetPosition(endIndex, hasHit ? hitInfo.point : transform.position + direction * distance);
    }

    void HandleOpponentSight(RaycastHit hitForward, RaycastHit hitRight, RaycastHit hitLeft)
    {
        bool stopOpponent = IsOpponentInMiddle(hitRight, hitLeft);
        Debug.Log("stop : " + stopOpponent);
        
        if (stopOpponent == true){

            GameObject opponent = GameObject.FindGameObjectWithTag("Opponent");
            if (opponent != null)
            {
                opponent.GetComponent<OpponentController>().SetPlayerInSight(true);
            }
        }
        /*if (hitForward.collider != null && hitForward.collider.CompareTag("Opponent"))
        {
            Debug.Log("Opponent in sight!");
            hitForward.collider.GetComponent<OpponentController>().SetPlayerInSight(true);
        }
        /*else if (hitRight.collider != null && hitRight.collider.CompareTag("Opponent"))
        {
            Debug.Log("Opponent to the right!");
            hitRight.collider.GetComponent<OpponentController>().SetPlayerInSight(true);
        }
        else if (hitLeft.collider != null && hitLeft.collider.CompareTag("Opponent"))
        {
            Debug.Log("Opponent to the left!");
            hitLeft.collider.GetComponent<OpponentController>().SetPlayerInSight(true);
        }*/
        else
        {
            Debug.Log("Nothing in sight!");
            GameObject opponent = GameObject.FindGameObjectWithTag("Opponent");
            if (opponent != null)
            {
                opponent.GetComponent<OpponentController>().SetPlayerInSight(false);
            }
        }
    }

    bool IsOpponentInMiddle(RaycastHit hitRight, RaycastHit hitLeft)
    {
        if ((hitRight.collider != null && hitRight.collider.CompareTag("Opponent") || hitLeft.collider != null && hitLeft.collider.CompareTag("Opponent")) && opponentNotInSight == true)
        {
            opponentInSight = true;
            opponentNotInSight = false;
        }
        else if ((hitRight.collider != null && hitRight.collider.CompareTag("Opponent") || hitLeft.collider != null && hitLeft.collider.CompareTag("Opponent")) && opponentNotInSight == false)
        {
            opponentInSight = false;
            opponentNotInSight = true;
        }
        return opponentInSight;
    }

    void RotateFieldOfVision()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * 100f);
    }
}
