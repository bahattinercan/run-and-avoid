using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapSounds : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.OnPaintFinished += OnPaintFinished;
    }

    private void OnPaintFinished()
    {
        audioSource.PlayOneShot(GameAssets.Instance.clapAudio);
    }
}
