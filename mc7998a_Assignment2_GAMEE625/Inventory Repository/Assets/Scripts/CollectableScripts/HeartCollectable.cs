using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class HeartCollectable : Collectable
{
    private int currentHealth; 
    public HealthBarScripts healthBar; 
    void Start()
    {
        name = "heart"; 
    }

    public override void Use() {
        healthBar.AddHealth(1);
        Destroy(gameObject);
    }
    public static event Action<Collectable> HeartPickUp;
    new protected void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            HeartPickUp?.Invoke(this);  
            Use();
        }
    }
}
