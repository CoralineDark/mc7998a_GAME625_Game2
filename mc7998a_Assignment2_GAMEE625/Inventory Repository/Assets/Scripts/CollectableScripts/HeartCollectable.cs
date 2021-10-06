using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    new protected void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            Use();
        }
    }
}
