using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float _speed; 
    private float _endPosX; 
    public void StartFloating(float endPosX)
    {
        _speed = Random.Range(1.0f,2.0f);
        _endPosX = endPosX; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed); 
        if (transform.position.x > _endPosX) {
                Destroy(gameObject); 
        }
    }
}
