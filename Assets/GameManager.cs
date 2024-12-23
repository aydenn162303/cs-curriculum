using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;
    private int Coins;
    private int health = 10;
    private int MAX_HEALTH = 10;

    public bool hasAxe = false;
    private bool udied = false;
    public bool hasBomb = false;
    public static GameManager gm;

    public int getHealth()
    {
        return health;
    }

    private void Start()
    {
        coinText.text = "Coins: " + Coins;
        healthText.text = "Health: " + health;
    }

    public void changeHealth(int amount)
    {
        health += amount;
        if (health > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }
        
        healthText.text = "Health: " + health;
        
        if (health < 1)
        {
            Die();
        }
    }

    void Die()
    {
        print("You died lol");
        Coins = 0;
        health = MAX_HEALTH;
        udied = true;
        SceneManager.LoadScene("Start");
        
        if (udied == true)
        {
            Destroy(gameObject);
            //Remove this if something is weird
        }
        
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

    public void AM_Coins(int cnumber)
    {
        Coins = Coins + cnumber;
        coinText.text = "Coins: " + Coins;
    }

    public int howManyCoins()
    {
        return Coins;
    }








}