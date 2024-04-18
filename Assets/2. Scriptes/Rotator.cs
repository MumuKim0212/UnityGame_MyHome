using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 60f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, speed * Time.deltaTime, 0f);
    }
}
