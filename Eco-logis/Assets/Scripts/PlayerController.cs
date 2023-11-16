using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fieldOfViewAngle = 90f; // Adjust as needed
    public float viewDistance = 100f; // Adjust as needed

    private LineRenderer lineRenderer;

    void Start()
    {
        // Create and configure the Line Renderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.green;
    }

    void Update()
    {
        RotateFieldOfVision();

        RaycastHit hit;
        // condition verifies if the ray hit something 
        if (Physics.Raycast(transform.position, transform.forward, out hit, viewDistance))
        {
            // check what did the ray hit 
            if (hit.collider.CompareTag("Opponent"))
            {
                Debug.Log("Opponent in sight!");
                hit.collider.GetComponent<OpponentController>().SetPlayerInSight(true);
            }
        }
        // if the ray does not hit anything
        else
            {
                Debug.Log("Nothing in sight!");
                // If opponent is not in sight, inform opponent
                GameObject opponent = GameObject.FindGameObjectWithTag("Opponent");
                if (opponent != null)
                {
                    opponent.GetComponent<OpponentController>().SetPlayerInSight(false);
                }
            }
        // Update Line Renderer positions
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * viewDistance);
        // Visualize the raycast in the Unity Editor
        Debug.DrawRay(transform.position, transform.forward * viewDistance, Color.green);

        // Draw a red line from the player's position to the hit point (if the ray hits something)
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
    }

    void RotateFieldOfVision()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * 100f);
        // Debug.Log("turning");
    }
}
