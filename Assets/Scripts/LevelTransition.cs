using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string nextLevel; // Assign the name of the next level in the Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the tag "Player"
        {
            SceneManager.LoadScene(nextLevel); // Load the next level
        }
    }
}
