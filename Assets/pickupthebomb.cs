using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupThebomb : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.hasBomb = true;
            Destroy(gameObject);
        }
    }
}
