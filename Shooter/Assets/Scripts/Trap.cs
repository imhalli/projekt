using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public Animator anim;
    private int i=0;
   
    public GameObject player;

    public float radius = 5.0F;
    public float power = 10.0F;

    public GameObject center;
    Vector3 explosionPos;

    Rigidbody rig;
   // Vector3 m_StartPos, m_StartForce;
    //public Vector3 m_NewForce;

    //string m_ForceXString, m_ForceYString;
    //float m_ForceX, m_ForceY;
    //float m_Result;

    // Use this for initialization
    void Start () {
        rig = player.GetComponent<Rigidbody>();
        explosionPos = center.transform.position;
        //m_NewForce = new Vector3(100.0f, 0.0f, 100.0f);
        //Initialising floats
        //m_ForceX = 100;
        //m_ForceY = 100;

        //m_ForceXString = "0";
        //m_ForceYString = "0";

        //The GameObject's starting position and Rigidbody position
        //m_StartPos = player.transform.position;
        //m_StartForce = transform.position;

        //m_NewForce = new Vector3(m_ForceX, 10 ,m_ForceY);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    

    IEnumerator Wait()
    {
        if (i == 0)
        {
            //Use Force as the force on GameObject’s Rigidbody
            //rig.AddForce(m_NewForce, ForceMode.Impulse);
            rig.AddExplosionForce(power, explosionPos, radius,0F);
            yield return new WaitForSeconds(0.5f);
            
            Destroy(gameObject);
        }
        i++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject.GetComponent <BoxCollider>());
            anim.SetBool("Exp", true);
            anim.SetBool("After", true);
            StartCoroutine(Wait());
            
        }


    }
}
