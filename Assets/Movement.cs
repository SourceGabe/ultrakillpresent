using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public CharacterController controller;

    public float speed = 12f;

    public float gravity = -5f;

    public float jumpHeight = 4f;


    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;
    Vector3 velocty;

    bool isGrounded;


    public float crouchSpeed;

    public float crouchYScale;

    private float startYScale;

    public KeyCode crouchKey = KeyCode.LeftControl;

    // Start is called before the first frame update
    void Start()
    {
    startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if(isGrounded && velocty.y < 0)
        {

            velocty.y = 0f;

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        velocty.y += gravity * Time.deltaTime;

        controller.Move(move * speed * Time.deltaTime);

        controller.Move(velocty * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocty.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if(Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            speed = 3f;
        }
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            speed = 12f;
        }
    }
}

