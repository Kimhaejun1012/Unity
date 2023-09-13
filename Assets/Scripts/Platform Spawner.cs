using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 3;


    public  float timeSpawnMin = 1.25f;
    public  float timeSpawnMax = 2.25f;
    private float timeSpawn;

    public float xPos = 20f;
    public float yMin = -3.5f;
    public float yMax = 1.5f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0f, -25f);
    private float lastSpawnTime;

    private void Start()
    {
        platforms = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }
        lastSpawnTime = 0f;
        timeSpawn = 0f;
    }

    private void Update()
    {
        if(GameManager.instance.IsGameOver)
        {
            return;
        }

        if(Time.time > lastSpawnTime + timeSpawn)
        {
            lastSpawnTime = Time.time;
            timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            var y = Random.Range(yMin, yMax);
            platforms[currentIndex].transform.position = new Vector2(xPos, y);

            currentIndex++;

            if(currentIndex >= platforms.Length)
            {
                currentIndex = 0;
            }

        }
    }
}
