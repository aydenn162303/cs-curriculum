using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.Mathematics;
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
    public GameObject bulletPrefab;

    private void OnTriggerStay2D(Collider2D other)
    {
        print("collision");
        if (other.gameObject.CompareTag("Player") && cooldown < 0)
        {
            print("player detected");
            GameObject clone = Instantiate(bulletPrefab, transform.position, quaternion.identity);
            Bullet script = clone.GetComponent<Bullet>();
            script.targetPos = other.gameObject.transform.position;
            cooldown = fireRate;
        }
        
    }
    
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
