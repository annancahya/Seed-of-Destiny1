using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    private CheckpointManager checkpointManager;
    private GameOverManager gameOverManager;
    public int maxHealth = 2;
    public int maxLives = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int currentHealth;
    private int currentLives;



    private void Start()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
        checkpointManager = FindObjectOfType<CheckpointManager>();
        ResetHealth();
        currentLives = maxLives; // 
    }

    private void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void Respawn()
    {
        if (currentLives > 1)
        {
            currentLives--;
            transform.position = checkpointManager.GetRespawnPoint();
            ResetHealth();
            Debug.Log("Respawning... Lives left: " + currentLives);
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        gameOverManager.ShowGameOver();
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Respawn();
        }
        else
        {
            Debug.Log("Health: " + currentHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            TakeDamage(2);
        }
        // else if (other.CompareTag("Obstacle"))
        // {
        //     TakeDamage(50);
        // }
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < currentLives; i++)
        {
            hearts[i].sprite = fullHeart;
        }

    }
}