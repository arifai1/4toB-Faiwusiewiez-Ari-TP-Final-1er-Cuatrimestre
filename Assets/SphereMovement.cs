using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereMovement : MonoBehaviour
{
    public int cantidaddeIns;
    public float TimeToIns;
    public float waitingtime;
    public float movementspeed = 0.1f;
    public float jumping;
    public GameObject mysphere;
    public GameObject perdiste;
    public GameObject ganaste;
    GameObject clone;
    Vector3 startPos;
    Rigidbody rb;
    bool jumpp;

    //public GameObject rain;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        perdiste.SetActive(!perdiste.activeInHierarchy);
        ganaste.SetActive(!ganaste.activeInHierarchy);
        rb = GetComponent<Rigidbody>();
        jumpp = true;
    }
    // Update is called once per frame
    void Update()
    {
        int tiempo = Mathf.FloorToInt(Time.time);
        transform.position += new Vector3(-movementspeed, 0, 0) * Time.deltaTime;
        //clone = Instantiate(mysphere);
        //clone.transform.position = transform.position + new Vector3(0, 0, 1);
        movementspeed = movementspeed + 0.1f;   

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, -movementspeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, movementspeed) * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.W) && jumpp)
        {
            rb.AddForce(Vector3.up * jumping, ForceMode.Impulse);
            jumpp = false;
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
            movementspeed = 0.1f;
        }
        if (coll.gameObject.name == "BaseD")
        {
            perdiste.SetActive(true);
            transform.position = startPos;
            movementspeed = 0.1f;
        }
        if (coll.gameObject.name == "Finish")
        {
            ganaste.SetActive(true);
            //Instantiate(ganaste);
            transform.position = startPos;
            movementspeed = 0.1f;
        }
        if (coll.gameObject.tag == "Ground")
        {
            jumpp = true;
        }
    }
    void OnCollisionExit(Collision ex)
    {
     //transform.position = startPos;
    }
        //public void CloneObject()
        //{
        //    int i = 1;
        //    while (i <= cantidaddeIns)
        //    {
        //        Instantiate(mysphere);
        //        i++;
        //    }
        //}

    }


