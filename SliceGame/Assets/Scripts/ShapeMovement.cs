using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement : MonoBehaviour {

    private Vector2 destinationPoint;
    private Vector2 spawnPoint;
    private Vector2 newPosition;
    public float movementDuration = 5f;
    private float lerpControlVar = 0;

    private bool startMove = false;
    
    private float degreesPerSecond = 90f;
    private int rotateDirection;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        if(Random.Range(0,2) == 0)
        {
            rotateDirection = 1;
        } else
        {
            rotateDirection = -1;
        }
    }

    void Update () {
        if (startMove)
        {
            if (lerpControlVar < 1)
            {
                lerpControlVar += Time.deltaTime / movementDuration;
            } else
            {
                Time.timeScale = 0;
            }
            newPosition = Vector2.Lerp(spawnPoint, destinationPoint, lerpControlVar);
            transform.position = newPosition;
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * degreesPerSecond * rotateDirection));
        }
    }

    public void SetDestinationPoint(float x, float y)
    {
        destinationPoint = new Vector2(x, y);
        startMove = true;
        //Debug.Log(destinationPoint);
    }

    public void SetMovementDuration(float movementDuration)
    {
        this.movementDuration = movementDuration;
    }
}
