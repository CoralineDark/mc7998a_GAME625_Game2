using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Default : Collectable
{   
    private void Start() { 
        stackable = true;
        itemType = ItemType.Default; 
    }
    
}