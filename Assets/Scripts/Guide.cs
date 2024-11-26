using System.Collections;
using UnityEngine;
using TMPro; // Pastikan menambahkan ini untuk TextMeshPro

public class Guide : MonoBehaviour
{
    public TMP_Text guide;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guide.gameObject.SetActive(true);
            // StartCoroutine(DisableNotificationAfterDelay());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            guide.gameObject.SetActive(false);
        }
    }

    // private IEnumerator DisableNotificationAfterDelay()
    // {
    //     yield return new WaitForSeconds(2f);
    //     guide.gameObject.SetActive(false);
    // }
}