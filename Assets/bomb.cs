using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private int bombTimer = 4000;
    public float force = 7f;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(6, force), ForceMode2D.Impulse);
    }

}
