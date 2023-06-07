using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName; // Name of the scene to transition to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the character has a "Player" tag
        {
         //   SceneManager.LoadScene(sceneName); // Load the new scene
        }
    }
}
