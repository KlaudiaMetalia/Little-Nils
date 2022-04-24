using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{



    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float starteTime = 12.0f;

    private float jumpForce = 5.0f;

    private bool isDead = false;

    private float animationDuration = 3.0f;

    private Animator jump;
    private Animator idle;
    private Animator lose;
    // Use this for initialization
    void Start()
    {
       jump = GetComponent<Animator>();
       idle = GetComponent<Animator>();
       lose = GetComponent<Animator>();
       controller = GetComponent<CharacterController>();
       starteTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (Time.time - starteTime < animationDuration)
        {
            //controller.Move(Vector3.forward * speed * Time.deltaTime);
            moveVector.x = 0.0f;
            moveVector.y = 0.5f;
            moveVector.z = 0.0f;
            transform.position = moveVector;

            idle.Play("Idle");
            //controller.Move(moveVector);
            //moveVector.y = verticalVelocity;
            return;
        }
        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
           // Debug.Log(controller.transform.position.y);
            verticalVelocity = -1.5f;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                controller.height = 1.0f;
                //Debug.Log(controller.height);
                verticalVelocity = jumpForce;
                jump.Play("Jump");
                controller.height = 2.0f;
            }
        }
        else
        {
            if (controller.transform.position.y < -1.5)
            {
                Death();
            }
            verticalVelocity -= gravity * Time.deltaTime;
        }
        // X Left , Right
        // Y UP, Down
        // Z Forward , Backward
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        // moveVector.x = Input.GetAxisRaw("Horizontal");
        controller.Move(moveVector * Time.deltaTime);

    }

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    //Thirret sa here karakteri yne perplaset me dicka
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("U perplas");
        if(hit.gameObject.tag == "Food")
        {
            //Debug.Log("Here");
            GetComponent<Score>().setScore(2);
            Destroy(hit.gameObject);
        }

        /*if(hit.point.z > transform.position.z + controller.radius / 2)
        {

        }*/
        if (hit.point.z > transform.position.z + controller.radius && hit.gameObject.tag == "Obstacle")
        {
            lose.Play("Lose");
            Death();
        }
    }

    private void Death()
    {

        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
