using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    Animator anim;
    Rigidbody rb;
    public VariableJoystick joy;
    bool jump;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
        ControllPlayer();

    }
    public void Jump()
    {
        Debug.Log("Jump함수");
        if (jump == false)
        {
            jump = true;
        }
    }
    void ControllPlayer()
    {
        float moveHorizontal;
        float moveVertical;
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveHorizontal = joy.Horizontal;
            moveVertical = joy.Vertical;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if ((Input.GetButtonDown("Jump") || jump) && Time.time > canJump)
        {
            rb.AddForce(0, jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }
        else if(jump)
        {
            Debug.Log("elseif");
            jump = false;
        }
    }
}