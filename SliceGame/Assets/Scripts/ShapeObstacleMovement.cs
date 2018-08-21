using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeObstacleMovement : MonoBehaviour {
    private Vector2 destinationPoint;
    private Vector2 spawnPoint;
    private Vector2 newPosition;
    private float movementDuration = 5f;
    private float lerpControlVar = 0;

    private float degreesPerSecond = 90f;
    private int rotateDirection;

    private void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        destinationPoint = spawnPoint * -1;
        if (Random.Range(0, 2) == 0)
        {
            rotateDirection = 1;
        }
        else
        {
            rotateDirection = -1;
        }
    }

    private void Update()
    {
        if (lerpControlVar < 1)
        {
            lerpControlVar += Time.deltaTime / movementDuration;
        }
        else
        {
            Destroy(this.gameObject);
        }
        newPosition = Vector2.Lerp(spawnPoint, destinationPoint, lerpControlVar);
        transform.position = newPosition;
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * degreesPerSecond * rotateDirection));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Time.timeScale = 0f;
        }
    }
}
