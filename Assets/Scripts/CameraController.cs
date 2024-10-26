using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Follow Player
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;  // Allows adjusting the camera position relative to the player
    [SerializeField] private float minX;     // Minimum X position the camera can move to (left boundary)
    [SerializeField] private float maxX;     // Maximum X position the camera can move to (optional, for right boundary)

    private void Update ()
    {
        // Hanya ikuti pemain jika posisi X pemain lebih besar dari batas minimum (minX)
        if (player.position.x > minX)
        {
            float targetX = player.position.x + offset.x;
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
        else
        {
            // Jika pemain berada di luar batas kiri, kamera akan stay di minX
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
    }


}
