using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{
    
    private List<Collectable> _inventory; 
    private Transform player; 
    
    private void Start() { 
        player = GameObject.Find("Player").GetComponent<Transform>(); 
    }

    
    public void drop() {
         
    }
}
