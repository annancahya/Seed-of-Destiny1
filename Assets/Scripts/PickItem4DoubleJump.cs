using System.Collections;
using UnityEngine;
using TMPro; // Pastikan menambahkan ini untuk TextMeshPro

public class PickItem4DoubleJump : MonoBehaviour
{
    public TMP_Text notificationText; 

    void Start()
    {
        if (notificationText != null)
        {
            notificationText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}