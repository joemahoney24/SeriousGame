using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    private bool grounded = false;
    private bool inputJump = false;

    public LayerMask groundLayers;
    public float spread = 0.1f;

    public Transform cameraTarget;
    public float cameraFollowSpeed;
    public Vector2 cameraOffset;
    public Vector2 cameraBounds;

    public TMP_Text variableText;
    public int SPF;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SPF = 10;
        StartCoroutine(DecreaseCountdown());
    }

    void Update()
    {
        Vector2 vel = rb.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        UpdateGrounding();

        inputJump = Input.GetKeyDown(KeyCode.Space);

        if (inputJump && grounded)
        {
            vel.y = jumpforce;
        }

        rb.velocity = vel;

        // Move the camera smoothly towards the target position
        Vector3 targetPosition = cameraTarget.position + new Vector3(cameraOffset.x, cameraOffset.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        Camera.main.transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, -cameraBounds.x, cameraBounds.x), Mathf.Clamp(smoothedPosition.y, -cameraBounds.y, cameraBounds.y), -10);

        variableText.text = "SPF " + SPF.ToString();
    }

    void UpdateGrounding()
    {
        Vector3 bottom = transform.position + Vector3.down * 0.45f;
        RaycastHit2D hit = Physics2D.Raycast(bottom, Vector2.down, 0.1f, groundLayers);

        Debug.DrawLine(bottom, bottom + Vector3.down * 0.1f, Color.red);

        grounded = hit.collider != null;
    }

    private IEnumerator DecreaseCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f); // Wait for 2 seconds
            SPF--; // Decrease the variable
        }
    }
}
