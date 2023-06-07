using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunscreenScript : MonoBehaviour
{
    // Collect the coin when the player touches it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player touched the coin
        if (collision.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    // Method to handle coin collection
    private void CollectCoin()
    {
        // Add your desired logic here
        // For example, increase the player's score or play a sound effect

        // Destroy the coin object
        Destroy(gameObject);
    }
}
