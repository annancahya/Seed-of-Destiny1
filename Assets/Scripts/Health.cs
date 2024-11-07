using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
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
    private SpriteRenderer spriteRenderer;
    public bool isDead = false;

    private void Start()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
        checkpointManager = FindObjectOfType<CheckpointManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetHealth();
        currentLives = maxLives;
        isDead = false;
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
            StartCoroutine(RespawnWithDelay(1f));
        }
        else
        {
            GameOver();
        }
    }

    private IEnumerator RespawnWithDelay(float delay)
    {
        spriteRenderer.enabled = false;
        isDead = true;

        yield return new WaitForSeconds(delay);

        transform.position = checkpointManager.GetRespawnPoint();
        ResetHealth();
        spriteRenderer.enabled = true;
        isDead = false;
        Debug.Log("Respawning... Lives left: " + currentLives);
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
