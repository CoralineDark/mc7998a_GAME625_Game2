using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds; 
    private float spawnInterval; 

    Vector2 startPos; 
    private GameObject endPosObj; 
    Vector2 endPos; 
    void Start()
    {
        endPosObj = GameObject.Find("CloudDespawner");
        endPos = endPosObj.transform.position;  
        startPos = transform.position;
        spawnInterval = 1.5f;  
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval); 
    }

    private void SpawnClouds(Vector2 startPos) {
        GameObject cloud = Instantiate(clouds[Random.Range(0,clouds.Length)]);
        cloud.transform.SetParent(GameObject.Find("Background Objects").GetComponent<Transform>()); 
        int offset = Random.Range(-5,10); 
        cloud.transform.position = new Vector2(startPos.x, startPos.y + offset); 
        cloud.GetComponent<CloudMovement>().StartFloating(endPos.x); 
    }

    private void AttemptSpawn() { 
        SpawnClouds(startPos);
        Invoke("AttemptSpawn", spawnInterval);  
    }

    private void Update() { 
    }

    private void Prewarm() {
        for (int i = 0; i < 10; i++)
        {
            Vector2 spawnPos = startPos + Vector2.right*(i*2); 
            SpawnClouds(spawnPos);
        } 
    }
}
