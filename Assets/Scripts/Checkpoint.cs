using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager manager = FindObjectOfType<CheckpointManager>();
            manager.SetCheckpoint(transform); // Set this object as the current checkpoint
        }
    }
}
