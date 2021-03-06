using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    // Use this for initialization
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffset;
        moveVector.x = 0;
        moveVector.y = 2.74f;//Mathf.Clamp(moveVector.y, 2, 5);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
        }
        else
        {
            //Animacioni ne fillim te lojes
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            // + Vector3.up
            transform.LookAt(lookAt.position + Vector3.up);
        }

    }
}
