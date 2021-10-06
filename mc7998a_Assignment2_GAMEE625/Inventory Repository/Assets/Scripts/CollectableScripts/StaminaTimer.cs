using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaTimer : MonoBehaviour
{
    public static float staminaTimer = 0.0f; 
    public Text stamCountDown; 
    void Start()
    {
        staminaTimer = 0.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        stamCountDown.text = "" + ((int)staminaTimer+1);
    }

    public void SetStamTimer(float time) { 
        staminaTimer = time; 
    }
}
