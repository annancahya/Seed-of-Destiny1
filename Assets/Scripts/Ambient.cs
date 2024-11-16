using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{

    AudioManager audioManager;
 

private void Start()
{
    AudioSource temp = gameObject.AddComponent<AudioSource>();
    temp.clip = audioManager.ambient;
    temp.Play();
    temp.Stop();
    Destroy(temp);
}
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlayAmbient(audioManager.ambient);
        }
    }

        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.StopAmbient(audioManager.ambient);
        }
    }
}
