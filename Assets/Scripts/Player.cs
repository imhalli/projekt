using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gunpoconiewiem;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public float waitTime;
    private Animator animator;

    public float moveSpeed;
    private Rigidbody myRig;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GameObject gun;
    
    // Use this for initialization
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        animator = gunpoconiewiem.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow) 
               || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            animator.SetBool("Run",true);

        else
            animator.SetBool("Run", false);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void FixedUpdate()
    {
        myRig.velocity = moveVelocity;
    }

   void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawnPoint.transform.position, gun.transform.rotation);
    }
}
