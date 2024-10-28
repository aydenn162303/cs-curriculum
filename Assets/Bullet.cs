using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private int _speed = 13;
    public Vector3 targetPos;
    private int desTime = -30;
    private int deathTimSet = 400;
    public GameManager gm;


    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

//FOR DEBUGGING BULLET SPAWNING
    //private void Start()
    //{
    //    print("one bullet spawned" + targetPos);
    //}    

    private void Update()
    {
        desTime -= 1;
        if (desTime > 0 && desTime < 30)
        {
            Destroy(gameObject);
        }

        // Move player thing
        if (transform.position == targetPos)
        {
            waitToDestroy();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.changeHealth(-1);
            Destroy(gameObject);
        }
    }

private void waitToDestroy()
    {
        if (desTime < 0) { desTime = deathTimSet;}
    }
    
}
