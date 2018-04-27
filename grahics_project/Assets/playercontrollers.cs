using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollers : MonoBehaviour
{
    public bool isGrounded;
    

    private float speed;
    public float rotSpeed;
    public float jumpHeight;
    private float w_speed = 0.05f;
    private float r_speed = 0.1f;
    Rigidbody rb;
    Animator anim;
    CapsuleCollider col_size;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col_size = GetComponent<CapsuleCollider>();
        isGrounded = true; //indicate that we are in the ground 
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {


            //standing controls
            if (Input.GetKey(KeyCode.W))
            {

                speed = w_speed;
                moveControl("isWalking");
                

            }
            else if (Input.GetKey(KeyCode.S))
            {
                speed = w_speed;
                moveControl("isWalking");

            }
            



            else if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = r_speed;
                //running control
                if (Input.GetKey(KeyCode.W))
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRunning", true);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRunning", true);

                }
                else
                {
                    anim.SetBool("isWalking", false);
                    anim.SetBool("isIdle", false);
                    anim.SetBool("isRunning", true);
                }
            }

            else
            {
                moveControl("isIdle");
            }

        }
        

        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z); transform.Rotate(0, y, 0);
        
            
        
    }
    void moveControl(string state)
    {
        switch (state)
        {
            case "isWalking":
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", false);
                break;

          
            

            case "isIdle":
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
                anim.SetBool("isIdle", true);
                break;
        }
    }

    void OnCollisionEnter()
    {
        isGrounded = true;
        
    }
}
