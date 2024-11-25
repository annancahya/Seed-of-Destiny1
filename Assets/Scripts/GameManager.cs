using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerLives = 3;
    public Vector3 playerPosition = Vector3.zero;
    public int currentLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);

        if (scene.buildIndex != 0)
        {
            if (scene.buildIndex == currentLevel)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    player.transform.position = playerPosition;
                }
            }

            SaveGame();
        }
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            lives = playerLives,
            playerPosition = playerPosition,
            currentLevel = currentLevel
        };
        SaveSystem.SaveGame(data);
        Debug.Log("Game saved at level: " + currentLevel);
    }

    public void LoadGame()
    {
        SaveData data = SaveSystem.LoadGame();
        if (data != null)
        {
            playerLives = data.lives;
            playerPosition = data.playerPosition;
            currentLevel = data.currentLevel;

            SceneManager.LoadScene(currentLevel);
        }
        else
        {
            Debug.Log("No saved game data found. Starting new game.");
            StartNewGame();
        }
    }

    public void StartNewGame()
    {
        SaveSystem.DeleteSave();
        playerLives = 3;
        playerPosition = Vector3.zero;
        currentLevel = 1; 

        Debug.Log("Starting New Game, Loading Cutscene with build index: " + currentLevel);
        SceneManager.LoadScene(currentLevel);
    }

    public void ProgressToNextLevel()
    {
        currentLevel++;
        Debug.Log("Progressing to next level (build index): " + currentLevel);

        if (currentLevel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentLevel);
            playerPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("No more levels to load.");
        }
    }
    public void ResetGame()
    {
        playerLives = 3;
        playerPosition = Vector3.zero;
    }
}
