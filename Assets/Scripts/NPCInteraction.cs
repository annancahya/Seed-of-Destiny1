using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Untuk menggunakan UI seperti Image

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionUI; // UI yang menunjukkan "Tekan E"
    public Image dialogueImage; // Komponen Image untuk dialog NPC
    public Sprite[] npcDialogues; // Array berisi gambar dialog NPC
    public Transform dialoguePosition; // Posisi di atas kepala NPC untuk menampilkan dialog

    private bool isPlayerInRange = false;
    private int currentDialogueIndex = 0;

    void Start()
    {
        // Pastikan UI interaksi dan dialog tidak terlihat pada awalnya
        interactionUI.SetActive(false);
        dialogueImage.gameObject.SetActive(false);
    }

    void Update()
    {
        // Jika pemain berada dalam jangkauan dan menekan tombol 'E'
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
            interactionUI.SetActive(false); // Sembunyikan "Tekan E" saat dialog muncul
        }
    }

    void ShowDialogue()
    {
        // Aktifkan gambar dialog di atas NPC
        dialogueImage.gameObject.SetActive(true);
        dialogueImage.sprite = npcDialogues[currentDialogueIndex];

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
            dialogueImage.gameObject.SetActive(false); // Sembunyikan dialog ketika keluar dari jangkauan
        }
    }
}
