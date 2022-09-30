using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void PlaySound(AudioClip clip) {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
    }
}
