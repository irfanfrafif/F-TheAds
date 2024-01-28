using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callAudio : MonoBehaviour
{
    private bool isHit;

    private void Start() {
        isHit = false;
    }

    private void Update() {
        PlayAudioHere();
    }

    public void PlayAudioHere() {
        if (!isHit) {
            AudioManager.instance.PlayAudio(6);
            isHit = true;
        }
    }
}
