using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGuyScript : MonoBehaviour
{

    public float speed;
    private int direction = -1;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.x = direction * speed;
        rb2d.velocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            direction = direction * -1;

            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            } else
            {
                spriteRenderer.flipX = true;
            }
        }

        if (collision.GetComponent<PlayerController>()) {
            Destroy(gameObject);
        }


    }

}
