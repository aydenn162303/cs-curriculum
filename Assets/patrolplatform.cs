using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class patrolplatform : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    
    private float _speed;
    private int currentPoint;
    private Vector2 targetPos;
    private bool touchPl = false;
    private States state;
    public GameManager gm;
    private GameObject player;


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

    


    void Update()
    {
        Patrol();
        
    }

  

    void Patrol()
    {
        transform.position =Vector2.MoveTowards(transform.position,waypoints[currentPoint].position, _speed * Time.deltaTime);
            
        if (Vector2.Distance(transform.position, waypoints[currentPoint].position) < 0.2f)
        {
            if (currentPoint < 3)
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

