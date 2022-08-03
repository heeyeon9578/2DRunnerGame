using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLand : MonoBehaviour
{
    public float speed = 10;
  
    void Update()
    {
        transform.position += Vector3.left * speed* Time.deltaTime; // -1,0,0 
      
    }
}
