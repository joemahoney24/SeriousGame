using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGuyScript : MonoBehaviour
{

    public float speed;
    private int direction = -1;
    protected Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
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
        }
    }

}
