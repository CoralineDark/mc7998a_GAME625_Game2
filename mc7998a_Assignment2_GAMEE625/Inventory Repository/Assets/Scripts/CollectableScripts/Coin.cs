using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class Coin : Default
{
    public int value;
    private void Start()
    {
        name = "Coin";
    }
    public override void Use() {
        CoinPurse.numCoins += 1;  
    }

}
