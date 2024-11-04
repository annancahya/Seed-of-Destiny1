using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    public int maxHealth = 2;
    public int maxLives = 3;

[SerializeField] private int currentHealth;
    private int currentLives;

    private void Start()
    {
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
        if (currentLives > 0)
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
    }
}