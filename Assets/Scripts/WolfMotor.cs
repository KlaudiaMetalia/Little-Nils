using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float starteTime = 12.0f;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        starteTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = -1.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;
        // moveVector.x = Input.GetAxisRaw("Horizontal");
        controller.Move(moveVector * Time.deltaTime);
    }
}
