using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    private bool inputJump = false;

    public LayerMask groundLayers;
    public float spread = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        inputJump = Input.GetKeyDown(KeyCode.Space);

        if(inputJump) {
            vel.y = jumpforce;
        }

        rb.velocity = vel;
    }
}
