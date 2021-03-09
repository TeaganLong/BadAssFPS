using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;
    float sprintTime = 0f;
    bool canSprint = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        Debug.Log(canSprint);
        if (sprintTime >= 100f)
        {
            canSprint = false;
        }

        if (sprintTime == 0)
        {
            canSprint = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (canSprint)
            {
                speed = 25f;
                sprintTime += 0.5f;
            }
            else
            {
                speed = 12f;
            }
        }
        else
        {
            speed = 12f;
            if (sprintTime > 0)
            {
                sprintTime -= 0.5f;
            }
        }
    }
}
