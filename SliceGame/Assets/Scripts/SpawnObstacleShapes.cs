using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleShapes : MonoBehaviour {

    public GameObject[] shapes;

    public float spawnTime = 1f;
    public float spawnTimeDec = 0.005f;

    private float lastSpawnTime;

    private float xCoord = 3.5f;
    private float yCoord = 5.5f;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update () {
        if (Time.time > lastSpawnTime + spawnTime)
        {
            SpawnShape();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnShape()
    {
        int shapeIndex = Random.Range(0, shapes.Length);
        Instantiate(shapes[shapeIndex], pickSpawnCoordinates(), Quaternion.identity);
        if (spawnTime > 0.5f)
        {
            spawnTime -= spawnTimeDec;
        }
    }

    private Vector2 pickSpawnCoordinates()
    {
        if(Random.Range(0, 2) == 0) // goes for x coordinate
        {
            if(Random.Range(0,2) == 0) // goes for positive x
            {
                return new Vector2(xCoord, Random.Range(-yCoord, yCoord));
            }
            else // goes for negative x
            {
                return new Vector2(-xCoord, Random.Range(-yCoord, yCoord));
            }
        }
        else // goes for y coordinate
        {
            if (Random.Range(0, 2) == 0) // goes for positive y
            {
                return new Vector2(Random.Range(-xCoord, xCoord), yCoord);
            }
            else // goes for negative y
            {
                return new Vector2(Random.Range(-xCoord, xCoord), -yCoord);
            }
        }
       
    }
}
