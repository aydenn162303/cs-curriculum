using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    
    private float _speed;
    private int currentPoint;
    private Vector2 targetPos;
    private bool seePl = false;
    

    void Start()
    {
        _speed = 2f;
        currentPoint = 0;
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            seePl = true;
            targetPos = other.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            seePl = false;
        }
    }

    void Update()
    {
        if (seePl)
        {
            transform.position =Vector2.MoveTowards(transform.position,targetPos, _speed * Time.deltaTime);
        }
        else
        {
            transform.position =Vector2.MoveTowards(transform.position,waypoints[currentPoint].position, _speed * Time.deltaTime);
            
            if (Vector2.Distance(transform.position, waypoints[currentPoint].position) < 0.2f)
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
    
}

