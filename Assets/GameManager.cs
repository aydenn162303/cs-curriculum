using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Coins;
    private int health = 10;
    private int MAX_HEALTH = 10;
    public static GameManager gm;

    public int getHealth()
    {
        return health;
    }

    public void changeHealth(int amount)
    {
        health += amount;
        if (health > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }

        if (health < 1)
        {
            Die();
        }


        
    }

    void Die()
    {
        print("You died lol");
        //Restart the level or something
    }
    
    private void Awake()
    {
        if(gm != null && gm!= this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
    }






}