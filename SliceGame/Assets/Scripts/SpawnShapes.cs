using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShapes : MonoBehaviour {

    public GameObject[] shapes;

    public Vector2[] shapesCoordinates;

    public float spawnTime = 1f;
    public float spawnTimeInc = 0.1f;

    private float lastSpawnTime;

    private int lastHealth = 1;

    private float movementDuration = 5f;
    private float movementDurationInc = 0.1f;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update () {
		if(Time.time > lastSpawnTime + spawnTime)
        {
            //Debug.Log("Spawn");
            SpawnShape();
            lastSpawnTime = Time.time;
        }
	}

    private void SpawnShape()
    {
        int shapeIndex = Random.Range(0, shapes.Length);
        int shapeCoordinatesIndex = Random.Range(0, shapesCoordinates.Length);
        GameObject shape = Instantiate(shapes[shapeIndex], shapesCoordinates[shapeCoordinatesIndex], Quaternion.identity);
        shape.GetComponent<ShapeHeart>().SetShapeLife(lastHealth);
        ShapeMovement shapeMovement = shape.GetComponent<ShapeMovement>();
        shapeMovement.SetMovementDuration(movementDuration);
        shapeMovement.SetDestinationPoint( -1 * shapesCoordinates[shapeCoordinatesIndex].x, -1 * shapesCoordinates[shapeCoordinatesIndex].y);
        lastHealth++;
        spawnTime += spawnTimeInc;
        movementDuration += movementDurationInc;
        movementDurationInc += 0.005f;
        spawnTimeInc += 0.005f;
    }
}
