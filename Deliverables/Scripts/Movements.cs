using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    // Public variables
    [Range(0f, 0.02f)]
    public float CharacterSpeed = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newLocalPos = transform.localPosition;

        if (Input.GetKey(KeyCode.A)) {
            newLocalPos.x -= CharacterSpeed;
            transform.localPosition = newLocalPos;
        }
        if (Input.GetKey(KeyCode.D)) {
            newLocalPos.x += CharacterSpeed;
            transform.localPosition = newLocalPos;
        }
        if (Input.GetKey(KeyCode.W)) {
            newLocalPos.z += CharacterSpeed;
            transform.localPosition = newLocalPos;
        }
        if (Input.GetKey(KeyCode.S)) {
            newLocalPos.z -= CharacterSpeed;
            transform.localPosition = newLocalPos;
        }
    }
}
