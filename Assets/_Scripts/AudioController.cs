using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    void Start()
    {
        audioSource.volume = GameManager.Instance.masterVolume;
    }
    private void Update()
    {
        audioSource.volume = GameManager.Instance.masterVolume;
    }
}
