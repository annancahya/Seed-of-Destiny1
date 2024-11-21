using System.Collections;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject confirmationCanvas;
    public TextMeshProUGUI textMeshProUGUI;

    public void Start()
    {
        SaveData data = SaveSystem.LoadGame();
        if (data != null)
        {
            textMeshProUGUI.text = "NEW GAME";
        }
        else
        {
            textMeshProUGUI.text = "START GAME";
        }
    }

    public void OnLoadButtonClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadGame();
        }
    }

    public void OnStartButtonClicked()
    {
        SaveData data = SaveSystem.LoadGame();
        if (data != null)
        {
            if (confirmationCanvas != null)
            {
                confirmationCanvas.SetActive(true);
            }
        }
        else
        {
            GameManager.instance.StartNewGame();
        }
    }

    public void StartGame()
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
