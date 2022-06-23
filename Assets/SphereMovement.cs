using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereMovement : MonoBehaviour
{
    public int cantidaddeIns;
    //public float TimeToIns;
    //public float waitingtime;
    public float movementspeed = 0.03f;
    public float jumping;
    float tiempoMuerte = 0;
    public GameObject mysphere;
    public GameObject perdiste;
    public GameObject ganaste;
    public GameObject CongratulationsIns;
    public GameObject CongratulationsIns2;
    GameObject clone;
    GameObject clone2;
    Vector3 startPos;
    Vector3 startFire;
    Vector3 startFire2;
    Rigidbody rb;
    bool jumpp;
    public AudioClip sound1;
    AudioSource sound2;
    public AudioClip explosion;
    AudioSource sound3;

    //public GameObject rain;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startFire = CongratulationsIns.transform.position;
        startFire2 = CongratulationsIns2.transform.position;
        perdiste.SetActive(!perdiste.activeInHierarchy);
        ganaste.SetActive(!ganaste.activeInHierarchy);
        rb = GetComponent<Rigidbody>();
        jumpp = true;
        sound2 = GetComponent<AudioSource>();
        sound3 = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > tiempoMuerte + 3)
        {
            int tiempo = Mathf.FloorToInt(Time.time);
            transform.position += new Vector3(-movementspeed, 0, 0) * Time.deltaTime;
            //clone = Instantiate(mysphere);
            //clone.transform.position = transform.position + new Vector3(0, 0, 1);
            movementspeed = movementspeed + 0.01f;
            perdiste.SetActive(false);
            ganaste.SetActive(false);
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
                sound2.clip = sound1;
                sound2.Play();
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.name);
        //if (coll.gameObject.name == "Plane")
        //{
        //    Destroy(clone);
        //    //ganaste.SetActive(true);            
        //}
        if (coll.gameObject.name == "Death")
        {
            ganaste.SetActive(false);
            perdiste.SetActive(true);
            transform.position = startPos;
            movementspeed = 0.01f;
            tiempoMuerte = Time.time;
            if (coll.gameObject.name == "Plane")
            {
                CongratulationsIns.transform.position = startFire;
                CongratulationsIns2.transform.position = startFire2;
                Destroy(clone, 3);
                Destroy(clone2, 3);
                
                perdiste.SetActive(true);
            }
        }
        if (coll.gameObject.name == "BaseD") //cuando colisiona con la base verde, se muestra el cartel "Perdiste" por 3 segundos y luego comienza el juego.
        {
            //perdiste.SetActive(true);
            //transform.position = startPos;
            //movementspeed = 0.01f;
            //if (coll.gameObject.name == "Plane")
            //{
            //    Destroy(clone);
            //    //perdiste.SetActive(true);
            //}
            ganaste.SetActive(false);
            perdiste.SetActive(true);
            transform.position = startPos;
            movementspeed = 0.01f;
            tiempoMuerte = Time.time;
            if (coll.gameObject.name == "Plane")
            {
                //Destroy(CongratulationsIns);
                //Destroy(CongratulationsIns2);
                Destroy(clone, 3);
                Destroy(clone2, 3);
                CongratulationsIns.transform.position = startFire;
                CongratulationsIns2.transform.position = startFire2;
                perdiste.SetActive(true);
            }
        }
        if (coll.gameObject.name == "Finish") //cuando colisiona con la pared final, se muestra el cartel "Ganaste" por 3 segundos y luego comienza el juego.
        {
            ganaste.SetActive(true);
            perdiste.SetActive(false);
            transform.position = startPos;
            for (int counter = 1; counter < cantidaddeIns; counter++)
            {
                sound3.clip = explosion;
                sound3.Play();
                clone = Instantiate(CongratulationsIns);
                clone2 = Instantiate(CongratulationsIns2);
                
                //Destroy(CongratulationsIns);
                //Destroy(CongratulationsIns2);
                Destroy(clone, 3);
                Destroy(clone2, 3);
                CongratulationsIns.transform.position = startFire;
                CongratulationsIns2.transform.position = startFire2;
            }
            movementspeed = 0.01f;
            tiempoMuerte = Time.time;

            
            
                
                //while (i <= cantidaddeIns)   //se intenta hacer el instantiate cuando vuelve al principio, y que cuando una pelotita pierda, pierdan todas, y vuelvan al principio.
                //{
                //  Instantiate(CongratulationIns);
                //  i++;
                //}
                //Destroy(clone, 2);

                //    if (coll.gameObject.name == "Plane")
                //{
                //    //int i = 0;
                //    //while (i <= cantidaddeIns)
                //    //{
                //    //    Instantiate(mysphere);
                //    //    i++;
                //    }

                if (coll.gameObject.name == "Death")
                {
                    perdiste.SetActive(true);
                    ganaste.SetActive(false);
                   // Destroy(CongratulationsIns);
                   // Destroy(CongratulationsIns2);
                    Destroy(clone);
                    Destroy(clone2);
                    CongratulationsIns.transform.position = startFire;
                    CongratulationsIns2.transform.position = startFire2;
                    Destroy(mysphere);
                    transform.position = startPos;
                }
                else if (coll.gameObject.name == "BaseD")
                {
                    perdiste.SetActive(true);
                    ganaste.SetActive(false);
                    //Destroy(CongratulationsIns);
                    //Destroy(CongratulationsIns2);
                    Destroy(clone, 3);
                    Destroy(clone2, 3);
                    CongratulationsIns.transform.position = startFire;
                    CongratulationsIns2.transform.position = startFire2;
                    Destroy(mysphere);
                    transform.position = startPos;
                }

            //}
            
            
            // ganaste.SetActive(true);

            //ganaste.SetActive(true);
            //perdiste.SetActive(false);
            //transform.position = startPos;
            //clone = Instantiate(mysphere);
            //clone.transform.position += new Vector3(0, 0, -movementspeed) * Time.deltaTime;
            //movementspeed = 0.01f;
            //if (clone.gameObject.name == "Death")
            //{
            //    perdiste.SetActive(false);
            //    //mysphere.transform.position = startPos;
            //    //clone.transform.position = startPos;
            //    movementspeed = 0.01f;
            //    //movementspeed = movementspeed);
            //    Destroy(clone);               
            //}
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


