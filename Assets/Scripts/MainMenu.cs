using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnLoadButtonClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadGame();
        }
    }

    public void OnStartButtonClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.StartNewGame();
        }
    }

    public void OnResetButtonClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
        }
    }


    public void Quitgame()
    {
        Application.Quit();
    }
}
