using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTitle : MonoBehaviour {

    public Vector2[] positions;

    private float rotDegreesZ = 10f;
    private int rotDirection = 1;

    private float animationTime = 4f;
    private float lastTime;

    private float lerpControlVar;
    private Vector2 actualPosition;
    private Vector2 newPosition;

    private void Start()
    {
        actualPosition = transform.position;
        PickNewPosition();
        lastTime = Time.time;
    }

    void Update () {
		if(Time.time < lastTime + animationTime)
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotDegreesZ * rotDirection / animationTime));
            lerpControlVar += Time.deltaTime / animationTime;
            transform.position = Vector2.MoveTowards(actualPosition, newPosition, Time.deltaTime*20f);
        }
        else
        {
            lastTime = Time.time;
            rotDirection *= -1;
            lerpControlVar = 0;
            actualPosition = transform.position;
        }
	}
    
    void PickNewPosition()
    {
        newPosition = positions[Random.Range(0, positions.Length)];
    }
}
