using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    
    private float _speed;
    private int currentPoint;
    private int targetPos;
    
    

    void Start()
    {
        _speed = 9f;
        currentPoint = 0;
    }
    
    void Update()
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

