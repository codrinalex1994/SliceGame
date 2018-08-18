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

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void Update () {
        if (startMove)
        {
            if (lerpControlVar < 1)
            {
                lerpControlVar += Time.deltaTime / movementDuration;
            }
            newPosition = Vector2.Lerp(spawnPoint, destinationPoint, lerpControlVar);
            transform.position = newPosition;
        }
    }

    public void SetDestinationPoint(float x, float y)
    {
        destinationPoint = new Vector2(x, y);
        startMove = true;
        Debug.Log(destinationPoint);
    }
}
