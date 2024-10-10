using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameManager gm;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            print("OWIE!! SPIKE!");
            gm.changeHealth(-1);

        }
    }


}
