using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CoinPurse : MonoBehaviour
{
    public static int numCoins = 0; 
    public Text coinText; 
    void Start()
    {
        numCoins = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "" + numCoins;
    }
}
