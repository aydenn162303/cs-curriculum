using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuptheaxe : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.hasAxe = true;
            Destroy(gameObject); 
        }
    }
}
