using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public GameObject mysphere;
    float movementspeed = 0.1f;
    float jumping = 0.15f;
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

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Death1")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death2")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death3")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death4")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death5")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death6")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death7")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death8")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death9")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death10")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death11")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death12")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death13")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
        else if (coll.gameObject.name == "Death14")
        {
            mysphere.transform.position = new Vector3(48, 1, 0);
        }
    }
    void OnCollisionExit(Collision ex)
    {
        transform.position = new Vector3(48, 1, 0);
    }

}
