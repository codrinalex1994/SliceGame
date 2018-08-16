using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeHeart : MonoBehaviour {

    private int health = 50;
    private Vector2 enteredPosition;
    private Vector2 exitedPosition;
    private float sliceLength;
    private float minSliceLength = 0.4f;

    private Vector3 shapeScale;
    private Vector3 hitShapeScale;
    private Vector3 scaleFactor;

    private void Start()
    {
        shapeScale = this.transform.localScale;
        hitShapeScale = shapeScale + (shapeScale * 1 / 8);
        scaleFactor = shapeScale * 1 / 2;
    }

    private void Update()
    {
        if( this.transform.localScale.magnitude > shapeScale.magnitude)
        {
            this.transform.localScale -= scaleFactor * Time.deltaTime; 
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enteredPosition = collision.attachedRigidbody.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        exitedPosition = collision.attachedRigidbody.transform.position;
        sliceLength = (exitedPosition - enteredPosition).magnitude;
        if( sliceLength > minSliceLength)
        {
            this.transform.localScale = hitShapeScale;
            health--;
        }
        if( health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
