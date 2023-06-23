using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator animator;
    float speed = 0.25f;
    float rotspeed = 80;
    float gravity = 8;
    float rot = 0;
    Vector3 moveDirection = Vector3.zero;
    public float jump=1;
    public float forward=1;
    CharacterController control;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        control= GetComponent<CharacterController>();
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();

        }

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetInteger("w", 1);
                moveDirection = new Vector3(1,0,0);
                moveDirection*=speed;
                moveDirection=transform.TransformDirection(moveDirection);
             if (Input.GetKey(KeyCode.Space)){
                transform.position += transform.forward * speed*Time.deltaTime;
            }
            
            }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetInteger("s", 1);
            moveDirection = new Vector3(-1, 0, 0);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("a", 1);
            moveDirection = new Vector3(0, 0, 1);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("d", 1);
            moveDirection = new Vector3(0, 0, -1);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetInteger("space", 1);
            rb.AddForce(new Vector3(0,jump,0));



        }
       
        else
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                moveDirection = new Vector3(0, 0, 0);
                animator.SetInteger("d", 0);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = new Vector3(0, 0, 0); 
                animator.SetInteger("w", 0);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                moveDirection = new Vector3(0, 0, 0);
                animator.SetInteger("a", 0);

            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                moveDirection = new Vector3(0, 0, 0);
                animator.SetInteger("s", 0);

            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                moveDirection = new Vector3(0, 0, 0);
                animator.SetInteger("space", 0);

            }

        }
        





    }
}
