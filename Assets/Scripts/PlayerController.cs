using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4;
    public float ySpeed = 6;
    float xDirection;
    float yDirection;
    float xVector;
    float yVector;
    public Transform trans;
    GameManager gm;
    private TopDown_AnimatorController animatorController;
    
    private bool jump;

    private RaycastHit2D leftray;
    
    private RaycastHit2D rightray;

    public bool overworld; 
    public GameObject bombPrefab;

    public bool facingRight = true;
    private float throwCooldown = 0;

    private void Start()
    {
        animatorController = FindObjectOfType<TopDown_AnimatorController>();
        gm = FindObjectOfType<GameManager>();
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        
        
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            ySpeed = 4;

        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            ySpeed = 0;
        }

        CheckAndSwitchWeapon();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Object.Destroy(other.gameObject);
            gm.AM_Coins(1);
            print("we have " + gm.howManyCoins() + " coins!");

        }


    }

    public void CheckAndSwitchWeapon()
    {
        if (gm.hasAxe)
        {
            animatorController.SwitchToAxe();
        }
        else
        {
            animatorController.SwitchToShovel();
        }
    }

    private void Update()
    {
        xDirection = Input.GetAxis("Horizontal");

        if (xDirection > 0)
        {
            facingRight = true;
        }
        else if (xDirection < 0)
        {
            facingRight = false;
        }
        
        yDirection = Input.GetAxis("Vertical");
    
        if (overworld != true)
        {
            jump = Input.GetKeyDown(KeyCode.Space);
        }
    
        xVector = Time.deltaTime * speed * xDirection;
        yVector = Time.deltaTime * ySpeed * yDirection;
        //left/right direction set variable
    
        trans.Translate(new Vector3(xVector, yVector, 0));
    
        leftray = Physics2D.Raycast(new Vector2(transform.position.x - trans.localScale.x / 6, transform.position.y), -Vector2.up, 0.9f);
        rightray = Physics2D.Raycast(new Vector2(transform.position.x + trans.localScale.x / 6, transform.position.y), -Vector2.up, 0.9f);
        Debug.DrawLine(new Vector2(transform.position.x + trans.localScale.x / 6, transform.position.y), new Vector2(transform.position.x + trans.localScale.x / 6, transform.position.y - 0.9f), Color.white);
        Debug.DrawLine(new Vector2(transform.position.x - trans.localScale.x / 6, transform.position.y), new Vector2(transform.position.x - trans.localScale.x / 6, transform.position.y - 0.9f), Color.white);
    
        if ((leftray.collider != null || rightray.collider != null) && jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7.5f), ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0) && throwCooldown < 0 && !overworld && gm.hasBomb)
        {
            throwCooldown = 2;
            if (facingRight)
            {
                var _vector = transform.position;
                _vector.x += 2;
                GameObject clone = Instantiate(bombPrefab, _vector, Quaternion.identity);
                bomb script = clone.GetComponent<bomb>();
                script.force = 7f;
            } 
            else 
            {
                var _vector = transform.position;
                _vector.x -= 2;
                GameObject clone = Instantiate(bombPrefab, _vector, Quaternion.identity);
                bomb script = clone.GetComponent<bomb>();
                script.force = -7f;
            }
        }

        throwCooldown -= Time.deltaTime;
            
    }
    //after all Unity functions, your own functions can go here
}