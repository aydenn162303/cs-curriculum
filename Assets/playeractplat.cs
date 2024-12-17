using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playeractplat : MonoBehaviour
{
    public List<Transform> waypoints1 = new List<Transform>();
    
    private float _speed;
    private int currentPoint;
    private Vector2 targetPos;
    private bool touchPl = false;
    private States state;
    public GameManager gm;
    private GameObject player;

    private bool activated = false;


    private enum States
    {
        patrol,
    }
    

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        state = States.patrol;
        _speed = 3.1f;
        currentPoint = 0;
    }

    
    void onTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activated = true;
        }
    }


    void Update()
    {
        if (activated)
        {
            Go();
        }
    }

  

    private void Go()
    {
        transform.position =Vector2.MoveTowards(transform.position,waypoints1[currentPoint].position, _speed * Time.deltaTime);
            
        if (Vector2.Distance(transform.position, waypoints1[currentPoint].position) < 0.2f)
        {
            if (currentPoint < 2)
            {
                currentPoint += 1;
            }
            else
            {
                currentPoint = 0;
            }
                
        }
    }
    

}

