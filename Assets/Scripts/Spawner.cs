using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject healPrefab;
    Vector2 screenSizeHalf;
    public float secondsBetweenSpawn = .25f;
    float nextSpawnTime;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax; //döndürme için

    // Start is called before the first frame update
    void Start()
    {
        screenSizeHalf = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
    

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenSizeHalf.x, screenSizeHalf.x ), screenSizeHalf.y + spawnSize); //calculate position
            GameObject newBlock = (GameObject) Instantiate(blockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));  //Quaternion.identity dönme yok demek
            newBlock.transform.localScale = Vector3.one * spawnSize;

            //farklı değişken kullanmadan yukarıdakileri kullanarak healPrefab için yarattım
            GameObject newHealBlock = (GameObject)Instantiate(healPrefab, new Vector2(Random.Range(-screenSizeHalf.x, screenSizeHalf.x), screenSizeHalf.y + Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y)), Quaternion.identity);
        }
        


    }


}
