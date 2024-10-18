using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    
    private float _speed;
    private int currentPoint;
    private Vector2 targetPos;
    private bool seePl = false;
    private States state;
    private float attackDelay = 0.2f;
    private float attackDelayWait = 0.5f;
    public GameManager gm;
    private GameObject player;


    private enum States
    {
        patrol,
        chase,
        attack,
        die
    }
    

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        state = States.patrol;
        _speed = 3.1f;
        currentPoint = 0;
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetPos = other.gameObject.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            player = other.GameObject();
            
            if (state == States.chase)
            {
                state = States.attack;
                print("enter attack");
            }

            if (state == States.patrol)
            {
                state = States.chase;
                print("enter chase");
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Reset the attack cooldown when it leaves a circle i kno
            attackDelay = attackDelayWait;
            
            if (state == States.chase)
            {
                state = States.patrol;
                print("exit to patrol");
            }

            if (state == States.attack)
            {
                state = States.chase;
                print("exit to chase");
            }
            
        }
    }

    void Update()
    {
        print("delay:" + attackDelay);
        if (attackDelay < 0)
        {
            attackDelay = attackDelayWait;
            hitPlayer();
        }
        
        if (state == States.chase)
        {
            Chase();
        }

        if (state == States.patrol)
        {
            Patrol();
        }

        if (state == States.attack)
        {
            attackDelayFunction();
        }
        
    }

    void Chase()
    {
        //move towards pl
        transform.position =Vector2.MoveTowards(transform.position,targetPos, _speed * Time.deltaTime);
        
    }


    void Patrol()
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

    void attackDelayFunction()
    {
        attackDelay -= 1 * Time.deltaTime;
    }

    void hitPlayer()
    {
        //find a way to hit the player and stuffffflkjhrljrthegukehfkjerqhfeirul
        gm.changeHealth(-2);
        
    }
    
    

}

