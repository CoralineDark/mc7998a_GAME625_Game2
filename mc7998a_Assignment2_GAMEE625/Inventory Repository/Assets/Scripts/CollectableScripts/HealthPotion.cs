using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPotion : SingleUseItem
{
    // Start is called before the first frame update 
    private void Start() { 
        name = "Health Potion"; 
    }

    public static event Action useHealthPotion;
    public override void Use()
    {
        useHealthPotion?.Invoke();
    }

}
