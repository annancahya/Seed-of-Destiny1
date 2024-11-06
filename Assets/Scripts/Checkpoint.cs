using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioManager audioManager;
    private bool isActivated = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            CheckpointManager manager = FindObjectOfType<CheckpointManager>();
            manager.SetCheckpoint(transform);
            audioManager.PlaySFX(audioManager.checkpoint);

        }
    }
}
