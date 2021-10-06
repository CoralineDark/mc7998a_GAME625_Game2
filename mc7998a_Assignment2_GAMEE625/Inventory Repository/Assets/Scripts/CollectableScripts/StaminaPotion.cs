using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class StaminaPotion : SingleUseItem
{
    //private int _staminaBoost = 10;  
    private void Start() { 
        name = "Health Potion"; 
    }
    public static event Action useStamPotion; 
    public override void Use()
    {
        useStamPotion?.Invoke();
        Destroy(gameObject);  
    }

}
