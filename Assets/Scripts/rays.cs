using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rays : MonoBehaviour
{
    public float speed;
    private int direction = -1;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DecreaseCountdown());
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.velocity;
        vel.y = direction * speed;
        rb2d.velocity = vel;
    }

    private IEnumerator DecreaseCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f); // Wait for 0.25 seconds
            direction =  direction * -1;
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>()) {
            Destroy(gameObject);
        }
    }
}
