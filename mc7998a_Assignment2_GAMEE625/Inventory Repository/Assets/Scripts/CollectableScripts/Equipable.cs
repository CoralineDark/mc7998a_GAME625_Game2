using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class Equipable : Collectable
{
    protected float atkBonus; 
    protected float defBonus;
    
    public static event Action<Equipable> equipItem; 
    public override void Use()
    {
        equipItem?.Invoke(this); 
    }
    public Equipable() {
        stackable = false;
        itemType = ItemType.Equipable; 
    }
    //protected abstract void DropItem(); 
}
