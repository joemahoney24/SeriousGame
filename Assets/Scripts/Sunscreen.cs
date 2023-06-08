using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunscreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with player!");
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }
}
