using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDot : MonoBehaviour {

    public GameObject dot;
    public float spawnDistanceX;
    public float spawnDistanceY;

    private Vector2 spawnPos;

    private float spawnTime = 4f;
    private float lastSpawnedTime;

    private int noOfDots = 1;

    private void Start()
    {
        lastSpawnedTime = Time.time;
    }

    void Update () {
		if(Time.time > lastSpawnedTime + spawnTime)
        {
            for(int i = 0; i < noOfDots; ++i)
            {
                SetSpawnPos();
                Instantiate(dot, spawnPos, Quaternion.identity);
            }
            lastSpawnedTime = Time.time;
        }
	}

    void SetSpawnPos()
    {
        spawnPos.x = Random.Range(-spawnDistanceX, spawnDistanceX);
        spawnPos.y = Random.Range(-spawnDistanceY, spawnDistanceY);
    }

    public void SetNoOfDots(int noOfDots)
    {
        this.noOfDots = noOfDots;
    }
}
