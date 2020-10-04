using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    float speed = 7f;

    //blokların gözükme-gözükmeme durumu için
    float visibleHeightThreshold;
    
    void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }


    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
