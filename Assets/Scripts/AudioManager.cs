using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] clip;

    private void Awake() {
        instance = this;
    }

    public void PlayAudio(int index) {
        audioSource.PlayOneShot(clip[index]);
    }


}
