using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickuptheaxe : MonoBehaviour
{
    private GameManager gm;
    private TopDown_AnimatorController animatorController;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        animatorController = FindObjectOfType<TopDown_AnimatorController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.hasAxe = true;
            animatorController.SwitchToAxe(); // Switch weapon to axe
            Destroy(gameObject); 
        }
    }
}
