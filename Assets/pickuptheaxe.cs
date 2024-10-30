using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTheAxe : MonoBehaviour
{
    private GameManager gm;
    private TopDown_AnimatorController animatorController;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        animatorController = FindObjectOfType<TopDown_AnimatorController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gm.hasAxe = true;
            other.GetComponent<PlayerController>().CheckAndSwitchWeapon(); // Call the method to switch weapon
            Destroy(gameObject);
        }
    }
}
