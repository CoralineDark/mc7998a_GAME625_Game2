using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHealth = 10; 
    public HealthBarScripts healthBar;
    private float _stamBoostTimer;
    public StaminaTimer staminaTimer; 
    public CharacterController2D charContr;
    public Inventory inventory; 
    public Transform equipmentSlot; 
    public Equipable equipped; 
    
    private void Start()
    {
        healthBar.SetMaxHealth(_maxHealth); 
        _stamBoostTimer = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) { 
            foreach (Transform child in equipmentSlot) {
                Destroy(child.gameObject); 
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            inventory.drop();  
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            inventory.useLastItem();
        }
        if (_stamBoostTimer > 0) { 
            _stamBoostTimer -= Time.deltaTime; 
        }
        else {
            charContr.setMovementSpeed(3.0f);
            charContr.setJumpForce(25.0f);
            _stamBoostTimer = 0;
            staminaTimer.gameObject.SetActive(false);  
        }
        staminaTimer.SetStamTimer(_stamBoostTimer);
    }
    private void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.tag == "Spike") {
            healthBar.SubHealth(1); 
        }
        
    }
    private void OnEnable() { 
        StaminaPotion.useStamPotion += StaminaBoost;
        HealthPotion.useHealthPotion += FullHeal;
        Equipable.equipItem += EquipItem;    
    }

    private void OnDisable() {
        StaminaPotion.useStamPotion -= StaminaBoost;
        HealthPotion.useHealthPotion -= FullHeal;
        Equipable.equipItem += EquipItem; 
    }
    public void StaminaBoost() { 
        charContr.setMovementSpeed(charContr.getMovementSpeed() * 1.5f);
        charContr.setJumpForce(charContr.getJumpForce() * 1.5f);
        _stamBoostTimer = 10f;
        staminaTimer.gameObject.SetActive(true);
    }

    public void EquipItem(Equipable item) {
        if (equipmentSlot.transform.childCount == 0) {
            item.transform.SetParent(equipmentSlot);
            item.transform.position = equipmentSlot.transform.position; 
            item.transform.rotation = equipmentSlot.transform.rotation;
        }
        else {
            foreach (Transform child in equipmentSlot) {
                Destroy(child.gameObject); 
            }
            item.transform.SetParent(equipmentSlot);
            item.transform.position = equipmentSlot.transform.position; 
            item.transform.rotation = equipmentSlot.transform.rotation;
        }
        equipped = item; 
        equipped.gameObject.SetActive(true);
    }

    public void FullHeal() {
        healthBar.SetHealth(_maxHealth);
    }

}
