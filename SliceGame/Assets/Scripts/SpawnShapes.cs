using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour {

    public GameObject[] shapes;

    public Vector2[] shapesCoordinates;

    public float spawnTime = 2f;

    private float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update () {
		if(Time.time > lastSpawnTime + spawnTime)
        {
            Debug.Log("Spawn");
            SpawnShape();
            lastSpawnTime = Time.time;
        }
	}

    private void SpawnShape()
    {
        int shapeIndex = Random.Range(0, shapes.Length);
        int shapeCoordinatesIndex = Random.Range(0, shapesCoordinates.Length);
        GameObject shape = Instantiate(shapes[shapeIndex], shapesCoordinates[shapeCoordinatesIndex], Quaternion.identity);
        shape.GetComponent<ShapeMovement>().SetDestinationPoint( -1 * shapesCoordinates[shapeCoordinatesIndex].x, -1 * shapesCoordinates[shapeCoordinatesIndex].y);
    }
}
