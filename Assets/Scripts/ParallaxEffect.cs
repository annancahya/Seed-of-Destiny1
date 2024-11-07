using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxMultiplier;  // Controls the intensity of parallax effect
    private Transform mainCamera;
    private Vector3 lastCameraPosition;

    void Start()
    {
        mainCamera = Camera.main.transform;
        lastCameraPosition = mainCamera.position;
    }

    void Update()
    {
        Vector3 deltaMovement = mainCamera.position - lastCameraPosition;
        transform.position += deltaMovement * parallaxMultiplier;
        lastCameraPosition = mainCamera.position;
    }
}
