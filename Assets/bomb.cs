using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private float bombTimer = 6f;

    private bool triggerCreated = false;
    private bool waitToDestroy = 0.2f;
    public float force = 7f;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 6), ForceMode2D.Impulse);
    }

    private void Explode()
    {
        StartCoroutine(FlashRed());
    }

    private IEnumerator FlashRed()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color originalColor = renderer.color;

        while (bombTimer > 0)
        {
            renderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            renderer.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }

        DestroySelf();
    }

    private void DestroySelf()
    {

        if (triggerCreated == false)
        {
            createTrigger();
            triggerCreated = true;
        }

        if (triggerCreated == true)
        {
            waitToDestroy -= Time.deltaTime;

            if (waitToDestroy < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (bombTimer > 0)
        {
            bombTimer -= Time.deltaTime;
            if (bombTimer <= 2)
            {
                Explode();
            }
        }
    }

    private void createTrigger()
    {
        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = 11f;
        circleCollider.offset = new Vector2(-0.15f, -0.61f);
        circleCollider.isTrigger = true;

    }


}
