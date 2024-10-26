using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteraction : MonoBehaviour
{
    public Camera mainCamera; // Assign the main camera in the Inspector
    public float zoomSize = 3f; // The size of the zoom
    public float normalSize = 5f; // Normal camera size
    public GameObject textUI; // The UI text that will display
    private bool isZoomed = false;

    public Vector3 zoomOffset; // Adjust X and Y during zoom

    private Vector3 originalCameraPosition; // Store the original position
    public Transform playerTransform; // Reference to the player's position

    void Start()
    {
        textUI.SetActive(false); // Hide the text at the start
        originalCameraPosition = mainCamera.transform.position; // Save the original position of the camera
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ZoomIn(other.transform); // Pass the player’s position to adjust the camera properly
            textUI.SetActive(true); // Show the text when player is near the paper
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ZoomOut();
            textUI.SetActive(false); // Hide the text when player moves away
        }
    }

    void ZoomIn(Transform player)
    {
        if (!isZoomed)
        {
            mainCamera.orthographicSize = zoomSize; // Zoom the camera
            mainCamera.transform.position = new Vector3(
                player.position.x + zoomOffset.x, // Move camera X based on player position + offset
                player.position.y + zoomOffset.y, // Move camera Y based on player position + offset
                originalCameraPosition.z); // Keep the camera’s Z position the same
            isZoomed = true;
        }
    }

    void ZoomOut()
    {
        if (isZoomed)
        {
            mainCamera.orthographicSize = normalSize; // Reset to normal size
            mainCamera.transform.position = originalCameraPosition; // Reset to the original position
            isZoomed = false;
        }
    }
}