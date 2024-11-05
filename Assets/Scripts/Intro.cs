using UnityEngine;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
