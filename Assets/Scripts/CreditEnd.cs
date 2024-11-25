using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditEnd : MonoBehaviour
{
    private void OnEnable()
    {
            SceneManager.LoadScene(0);
            SaveSystem.DeleteSave();
    }
}
