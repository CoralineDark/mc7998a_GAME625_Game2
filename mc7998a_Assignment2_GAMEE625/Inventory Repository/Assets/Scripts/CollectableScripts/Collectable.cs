using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Collectable : MonoBehaviour
{
    public enum ItemType {
        Default, 
        Equipable, 
        SingleUseItem
    }
    public ItemType itemType; 
    public bool stackable; 
    protected new string name; 
    [TextArea(15,20)]
    public string description;  
    public GameObject prefab;
    public GameObject sound; 
    public static event Action<Collectable> ItemPickup;
    public static event Action DisplayItems; 
    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            ItemPickup?.Invoke(this);
            DisplayItems?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public abstract void Use();
}
