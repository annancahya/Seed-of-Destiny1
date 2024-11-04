using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform lastCheckpoint;

    public void SetCheckpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public Vector2 GetRespawnPoint()
    {
        if (lastCheckpoint != null)
            return lastCheckpoint.position;

        return new Vector2(0, 0);
    }
}
