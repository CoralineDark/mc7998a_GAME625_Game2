using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsManager : MonoBehaviour
{

    public AudioClip newClip; 
    private void OnEnable() { 
        Collectable.ItemPickup += PlaySound;
        HeartCollectable.HeartPickUp += PlaySound;   
    }

    private void OnDisable() {
        Collectable.ItemPickup -= PlaySound; 
    }
    
    public void PlaySound(Collectable item) { 
        newClip = item.gameObject.GetComponent<AudioSource>().clip; 
        gameObject.GetComponent<AudioSource>().clip = newClip; 
        gameObject.GetComponent<AudioSource>().Play(); 
    }
}
