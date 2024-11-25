using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSkip : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            SaveSystem.DeleteSave();
        }
    }
}