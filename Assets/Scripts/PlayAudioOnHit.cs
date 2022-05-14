using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnHit : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameManager.Instance.AudioSource;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
