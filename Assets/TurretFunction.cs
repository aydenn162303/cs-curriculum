using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class TurretFunction : MonoBehaviour
{
    private int player;
    private int distance;
    private float cooldown = 1;
    private int projectile;
    private float fireRate = 2;
    private int bullet;


    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player") || cooldown < 0)
        {
            Bullet bullet = Instantiate(projectile).GetComponent<Bullet>();

            bullet.targetPos = player.transform.position;
            cooldown = fireRate;
        }
        
    }
    
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
