using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Untuk menggunakan UI seperti Text

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionUI; // UI yang menunjukkan "Tekan E"
    public TextMeshProUGUI dialogueText; // TMP untuk dialog NPC
    public string[] npcDialogues; // Array berisi dialog NPC
    public Transform dialoguePosition; // Posisi di atas kepala NPC untuk menampilkan dialog

    private bool isPlayerInRange = false;
    private int currentDialogueIndex = 0;

    void Start()
    {
        // Pastikan UI interaksi dan dialog tidak terlihat pada awalnya
        interactionUI.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Jika pemain berada dalam jangkauan dan menekan tombol 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }
    }

    void ShowDialogue()
    {
        // Aktifkan teks dialog di atas NPC
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = npcDialogues[currentDialogueIndex];

        // Meningkatkan indeks dialog (loop kembali ke awal jika sudah di akhir)
        currentDialogueIndex = (currentDialogueIndex + 1) % npcDialogues.Length;
    }

    // Ketika pemain memasuki area NPC
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionUI.SetActive(true); // Tampilkan teks "Tekan E"
        }
    }

    // Ketika pemain keluar dari area NPC
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionUI.SetActive(false); // Sembunyikan teks "Tekan E"
            dialogueText.gameObject.SetActive(false); // Sembunyikan dialog ketika keluar dari jangkauan
        }
    }
}
