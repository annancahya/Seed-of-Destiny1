using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointManager manager = FindObjectOfType<CheckpointManager>();
            manager.SetCheckpoint(transform);
            audioManager.PlaySFX(audioManager.checkpoint);

        }
    }
}
