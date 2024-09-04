using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    float xSpeed;
    float ySpeed;
    float xDirection;
    float yDirection;
    float xVector;
    float yVector;
    float horizontalInput;
    float verticalInput;
    Rigidbody2D rb;

    void Start()
    {
        xSpeed = 4;
        ySpeed = 4;
        xDirection = 0;
        xVector = 0;


    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        xVector = xSpeed * xDirection;
        yVector = ySpeed * yDirection;
        transform.Translate(xVector, yVector,0);


    }

}
