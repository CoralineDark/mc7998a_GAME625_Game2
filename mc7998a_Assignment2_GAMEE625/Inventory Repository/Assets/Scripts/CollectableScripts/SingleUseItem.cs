using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public abstract class SingleUseItem : Collectable
{
    public SingleUseItem() {
        stackable = true;
        itemType = ItemType.SingleUseItem;
    }
}
