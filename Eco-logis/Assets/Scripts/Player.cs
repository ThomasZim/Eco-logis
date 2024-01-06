using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[ExecuteInEditMode]
public class Player : MonoBehaviour
{
    public float distance = 10;
    public float angle = 30;
    public float height = 0.5f;
    public Color meshColor = Color.red;

    public int scanFrequency = 30;
    public LayerMask layers;

    public List<GameObject> Objects = new List<GameObject>();

    Collider[] colliders = new Collider[50];
    Mesh mesh;
    int count;
    float scanInterval;
    float scanTimer;


    void Start(){   
        mesh = CreateWedgeMesh();
        scanInterval = 1.0f / scanFrequency;
        


    }
    void Update(){
    
        Vector3 forwardDirection = transform.forward;
        RaycastHit hitForward;
    

        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationSpeed = 90f; // You can adjust this value
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);


        scanTimer -= Time.deltaTime;
        if (scanTimer < 0){
            scanTimer += scanInterval;
            //Scan();
            DetectKidInSight();
        }

        // End game check
        if (CoreMechanics.isFinised)
        {
            if (CoreMechanics.isVictory)
            {
                SceneManager.LoadScene("Winning_end");
            }
            else
            {
                SceneManager.LoadScene("Losing_end");
            }
        }
    }
    private void DetectKidInSight()
    {
        Collider[] kidColliders = Physics.OverlapSphere(transform.position, distance, layers, QueryTriggerInteraction.Collide);
        
        foreach (Collider collider in kidColliders)
        {
        
            GameObject kidObj = collider.gameObject;
            if (kidObj.CompareTag("Kid")){
                GameObject kid = kidObj;
                if (IsInSight(kid))
                {
                    Debug.Log(kid.name);
                    if(kid.GetComponent<kidBehaviour>() != null)
                    {
                        kid.GetComponent<kidBehaviour>().SetPlayerInSight(true);
                    }
                    if(kid.GetComponent<secondkidBehaviour>() != null)
                    {
                        kid.GetComponent<secondkidBehaviour>().SetPlayerInSight(true);
                    }
                    
                }
                else
                {
                    if(kid.GetComponent<kidBehaviour>() != null)
                    {
                        kid.GetComponent<kidBehaviour>().SetPlayerInSight(false);
                    }
                    if(kid.GetComponent<secondkidBehaviour>() != null)
                    {
                        kid.GetComponent<secondkidBehaviour>().SetPlayerInSight(false);
                    }
                }
            }   
        }
    }
    private void Scan(){
        count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, layers, QueryTriggerInteraction.Collide);

        Objects.Clear();

        for(int i = 0; i < count; ++i) {
            GameObject obj = colliders[i].gameObject;
            bool seeKid = obj.CompareTag("Kid");
            Debug.Log(seeKid);
            Debug.Log("seeing something :" + IsInSight(obj));
            if(IsInSight(obj) && seeKid){
                Debug.Log("YES");
                if(seeKid){
                    Debug.Log("see kid");
                    obj.GetComponent<kidBehaviour>().SetPlayerInSight(seeKid);
                }
            
                Objects.Add(obj);

                }
        }
    }

    public bool IsInSight(GameObject obj){
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;
        //Debug.Log("sight obj " + obj);
        if(direction.y < 0 || direction.y > height){
            return false;
        }
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction,transform.forward);
        if (deltaAngle > angle) {
            return false;
        } 
         
        return true;
    }

    Mesh CreateWedgeMesh(){

        Mesh mesh = new Mesh();

        int numTriangles = 8;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles= new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;
        
        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;

        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        //far side
        vertices[vert++] = bottomLeft;
        vertices[vert++] = bottomRight;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = topLeft;
        vertices[vert++] = bottomLeft;

        //top
        vertices[vert++] = topCenter;
        vertices[vert++] = topLeft;
        vertices[vert++] = topRight;

        //bottom
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomLeft;

        for(int i = 0 ; i < numVertices; ++i){
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        
        return mesh;
    }
 
    private void OnValidate() {
        mesh = CreateWedgeMesh();
        scanInterval = 1.0f / scanFrequency;
    }

    private void OnDrawGizmos() {
        if(mesh) {
            Gizmos.color = meshColor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
        
        //Gizmos.DrawWireSphere(transform.position, distance);
        for(int i = 0; i<count; ++i) {
            //Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }

        Gizmos.color = Color.green;
        //foreach (var obj in Objects){
            //Gizmos.DrawSphere(obj.transform.position, 0.2f);
        //}

    }


}
