using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform lastCheckpoint;

    public void SetCheckpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;

        if (GameManager.instance != null)
        {
            GameManager.instance.playerPosition = checkpoint.position;
            GameManager.instance.SaveGame();
            Debug.Log("Checkpoint reached at position: " + checkpoint.position);
        }
        else
        {
            Debug.LogWarning("GameManager instance is null. Cannot save game.");
        }
    }

  
    public Vector2 GetRespawnPoint()
    {
        if (lastCheckpoint != null)
            return lastCheckpoint.position;

        return new Vector2(0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetCheckpoint(transform);
        }
    }
}
