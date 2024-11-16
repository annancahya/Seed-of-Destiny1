using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource ambientSource;

    public AudioClip background;
    public AudioClip ambient;
    public AudioClip jump;
    public AudioClip steps;
    public AudioClip dash;
    public AudioClip checkpoint;
    public AudioClip die;
    public AudioClip respawn;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlayAmbient(AudioClip clip)
    {
        ambientSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopAmbient(AudioClip clip)
    {
        if (ambientSource.isPlaying)
        {
            ambientSource.Stop();
        }
    }


}

