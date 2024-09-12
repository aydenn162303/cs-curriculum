using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    float xDirection;
    float yDirection;
    float xVector;
    float yVector;
    float coin = 0;
    public Transform trans;

    public bool overworld; 

    private void Start()
    {
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?

        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coin = coin + 1;
            print("I have " + coin + " coins! woah.");

        }


    }


    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");

        xVector = Time.deltaTime * speed * xDirection;
        yVector = Time.deltaTime * speed * yDirection;

        trans.Translate(new Vector3(xVector, yVector, 0));


    }
    //after all Unity functions, your own functions can go here
}