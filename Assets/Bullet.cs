using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private int _speed = 8;
    public Vector3 targetPos;
    private int desTime = -30;
    private int deathTimSet = 400;

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

    private void waitToDestroy()
    {
        if (desTime < 0) { desTime = deathTimSet;}
    }
    
}
