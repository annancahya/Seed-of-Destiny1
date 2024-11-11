using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D next)
    {
        if (next.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.instance.ProgressToNextLevel();
        }
    }
}
