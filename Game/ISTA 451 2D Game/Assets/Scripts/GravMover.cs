using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravMover : MonoBehaviour {

    public float Speed = 0;

    private bool isJumping = false;
    private bool foundFooting = false;
    private bool pulledDown = true;
    private Rigidbody2D rb;
    private float scaleX;
    private float scaleY;
    private bool doubleJump;
    private bool inJump;
    private bool gravSwap;


    private Animator animator;
    //used for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        animator = GetComponent<Animator>();
        doubleJump = false;
        inJump = false;

    }
 

    //checking if the object is in contact with the 'Floor GameObject'
    void OnCollisionStay2D(Collision2D col)
    {
        GameObject obj = col.gameObject;
        if (obj.tag == "Floor")
        {
            foundFooting = true;
            pulledDown = false;
            inJump = false;
            return;
        }
        else
        {
            foundFooting = false;
            pulledDown = true;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        foundFooting = false;
        if (inJump)
        {
            animator.Play("FallingAnimation");
        }
        else
        {
            animator.Play("FullJumpAnimation");
        }
        pulledDown = true;

    }

    // Update is called once per frame
    void Update()
    {



        //Right movement thorough Right arrow key
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 vehicleposition = new Vector3(transform.position.x * Time.deltaTime, transform.position.y, transform.position.z);
            vehicleposition.x = transform.position.x + Speed / 100;
            transform.position = vehicleposition;
            if (foundFooting && !pulledDown)
            {
                animator.Play("RunAnimation");
            }
            transform.localScale = new Vector2(scaleX, scaleY);


        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 vehicleposition = new Vector3(transform.position.x * Time.deltaTime, transform.position.y, transform.position.z);
            vehicleposition.x = transform.position.x - Speed / 100;
            transform.position = vehicleposition;
            if (foundFooting && !pulledDown)
            {
                animator.Play("RunAnimation");
            }
            transform.localScale = new Vector2(-scaleX, scaleY);
        }
        else
        {
            if (foundFooting && !pulledDown)
            {

                animator.Play("IdleAnimation");


            }
        }

        // Swaps gravity when space is pressed and the character is on the ground

        if (Input.GetKeyDown(KeyCode.Space) && foundFooting)
        {
            isJumping = true;
            gravSwap = !gravSwap;

            if (gravSwap)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + GetComponent<BoxCollider2D>().bounds.size.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - GetComponent<BoxCollider2D>().bounds.size.y);
            }
        }
        else
        {
            isJumping = false;
        }

        //Enabling OR disabling jump bool conditions
        if (isJumping && ((foundFooting && !pulledDown) || (doubleJump)))
        {
            if (!(foundFooting && !isJumping))
            {
                pulledDown = false;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                doubleJump = false;
            }
        }

        if (rb.velocity.y < 0)
        {
            inJump = true;
        }

        if (gravSwap)
        {
            GetComponent<Rigidbody2D>().gravityScale = -4;
            transform.localScale = new Vector3(transform.localScale.x,-1,1);
            
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 4;
            transform.localScale = new Vector3(transform.localScale.x, 1, 1);
            
        }


    }
}
