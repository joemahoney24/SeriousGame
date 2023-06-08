using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    private bool grounded = false;
    private bool inputJump = false;

    public LayerMask groundLayers;

    public Transform cameraTarget;
    public float cameraFollowSpeed;
    public Vector2 cameraOffset;
    public Vector2 cameraBounds;

    public TMP_Text variableText;
    public int SPF;

    public SpriteRenderer sunSprite;
    public float maxSize;
    public float minSize;

    private bool shade = false;

    public GameObject winCondition;
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;

    public SpriteRenderer characterSprite;
    public Sprite[] walkingSprites;
    public float spriteAnimationSpeed;
    

    private bool isWalking = false;
    private bool isFacingRight = true;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SPF = 20;
        StartCoroutine(DecreaseCountdown());

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.Play();
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

        Vector3 targetPosition = cameraTarget.position + new Vector3(cameraOffset.x, cameraOffset.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        Camera.main.transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, -cameraBounds.x, cameraBounds.x), Mathf.Clamp(smoothedPosition.y, -cameraBounds.y, cameraBounds.y), -10);

        variableText.text = "SPF " + SPF.ToString();

        if (SPF <= 0)
        {
            SceneManager.LoadScene("Melanoma.");
        }

        // Check for collision with the win condition
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.5f, 0.5f), 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == winCondition)
            {
                // Destroy(gameObject);
                Debug.Log("You win!");
                SceneManager.LoadScene("WinningScene");
            }

            if (collider.gameObject == levelOne)
            {
                SceneManager.LoadScene("Charlie's Scene");
            }

            if(collider.gameObject == levelTwo)
            {
                SceneManager.LoadScene("Ben's Scene");
            }

            if(collider.gameObject == levelThree)
            {
                SceneManager.LoadScene("RabbaiBill's Scene");
            }
        }

        // Calculate the size of the sun sprite based on SPF
        float t = 1f - Mathf.InverseLerp(0, 20, SPF); // Invert the value of t
        float newSize = Mathf.Lerp(minSize, maxSize, t);
        sunSprite.transform.localScale = new Vector3(newSize, newSize, 1);

        //float t = Mathf.InverseLerp(0, 10, SPF);
        //float newSize = Mathf.Lerp(minSize, maxSize, t);
        //sunSprite.transform.localScale = new Vector3(newSize, newSize, 1);



        Vector2 vel2 = rb.velocity;
        vel2.x = Input.GetAxis("Horizontal") * speed;

        // Check if the player is moving horizontally
        if (vel2.x != 0 && grounded)
        {
            if (!isWalking)
            {
                isWalking = true;
                StartCoroutine(AnimateWalkingSprites());
            }

            if ((vel.x < 0 && isFacingRight) || (vel.x > 0 && !isFacingRight))
            {
                FlipCharacterSprite();
            }



        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                StopCoroutine(AnimateWalkingSprites());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shade"))
        {
            shade = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            SPF = SPF - 10;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shade"))
        {
            shade = false;
        }
    }


    private IEnumerator AnimateWalkingSprites()
    {
        int index = 0;

        while (isWalking)
        {
            characterSprite.sprite = walkingSprites[index];

            index++;
            if (index >= walkingSprites.Length)
                index = 0;

            yield return new WaitForSeconds(spriteAnimationSpeed);
        }
    }


    private void FlipCharacterSprite()
    {
        isFacingRight = !isFacingRight;
        characterSprite.flipX = !isFacingRight;
    }

    void UpdateGrounding()
    {
        Vector3 bottom = transform.position + Vector3.down * 0.8f + Vector3.left * 0.4f;
        RaycastHit2D hit = Physics2D.Raycast(bottom, Vector2.down, 0.1f, groundLayers);

        Debug.DrawLine(bottom, bottom + Vector3.down * 0.1f, Color.red);

        grounded = hit.collider != null;
    }

    private IEnumerator DecreaseCountdown()
    {
        while (true)
        {
            if (!shade)
            {
                yield return new WaitForSeconds(0.25f); // Wait for 0.25 seconds
                SPF--; // Decrease the SPF variable
            }

            yield return new WaitForSeconds(0.25f);
        }
    }
}