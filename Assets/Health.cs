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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            print("OWIE!! SPIKE!");
            gm.changeHealth(-1);

        }
    }


}
