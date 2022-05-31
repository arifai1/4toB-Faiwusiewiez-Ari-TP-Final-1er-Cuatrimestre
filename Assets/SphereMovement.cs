using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereMovement : MonoBehaviour
{
    //public GameObject mysphere;
    public float movementspeed = 0.1f;
    public float jumping = 0.15f;
    Vector3 startPos;
    public GameObject perdiste;
    public GameObject ganaste;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        perdiste.SetActive(!perdiste.activeInHierarchy);
        ganaste.SetActive(!ganaste.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-movementspeed, 0, 0) * Time.deltaTime;
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, -movementspeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, movementspeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, jumping, 0) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        perdiste.SetActive(false);
        ganaste.SetActive(false);
        if (coll.gameObject.name == "Plane")
        {
            ganaste.SetActive(false);
            perdiste.SetActive(false);            
        }
        if (coll.gameObject.name == "Death")
        {
            perdiste.SetActive(true);
            transform.position = startPos;
        }
        if (coll.gameObject.name == "BaseD")
        {
            perdiste.SetActive(true);
            transform.position = startPos;
        }

        if (coll.gameObject.name == "Finish")
        {
            ganaste.SetActive(true);
            transform.position = startPos;
        }      
                
    }
    




    void OnCollisionExit(Collision ex)
    {
        //transform.position = startPos;
    }

}
