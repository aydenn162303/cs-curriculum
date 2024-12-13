using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomWall : MonoBehaviour
{

    private float destroy = 1f;

    private bool bombNear = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bomb"))
        {
            if (bombNear == false)
            {
                bombNear = true;
                GetComponent<Rigidbody2D>().gravityScale = 0.8f;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 300), ForceMode2D.Impulse);
            }
        }
    }

    void Update()
    {
        if (bombNear == true)
        {
            destroy -= Time.deltaTime;

            if (destroy < 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
