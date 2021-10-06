using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{

    [SerializeField] private List<AudioSource> sounds; 
    private AudioSource audioData;
    private void OnEnable() { 
        Collectable.ItemPickup += PlaySound;  
    }

    private void OnDisable() {
        Collectable.ItemPickup -= PlaySound; 
    }

    private void PlaySound(Collectable item) {
        audioData = item.GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log(audioData.name);
    }
}
