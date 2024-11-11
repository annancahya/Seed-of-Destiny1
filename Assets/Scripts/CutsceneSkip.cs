using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnSpace : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.instance.ProgressToNextLevel();
        }
    }
}