using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public GameObject mysphere;
    float movementspeed = 0.1f;
    float jumping = 0.2f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mysphere.transform.position += new Vector3(-movementspeed, 0, 0);
        if(Input.GetKey(KeyCode.A))
        {
            mysphere.transform.position += new Vector3(0, 0, -movementspeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mysphere.transform.position += new Vector3(0, 0, movementspeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            mysphere.transform.position += new Vector3(0, jumping, 0);
        }
    }
}
