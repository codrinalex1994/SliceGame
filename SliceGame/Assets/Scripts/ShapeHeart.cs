﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeHeart : MonoBehaviour {

    private int health = 10;
    private Vector2 enteredPosition;
    private Vector2 exitedPosition;
    private float sliceLength;
    private float minSliceLength = 0.2f;

    private Vector3 shapeScale;
    private Vector3 hitShapeScale;
    private Vector3 scaleFactor;

    public GameObject sliceCountText;
    private TextMesh textMesh;

    private bool isCollidingWithCursor = false;

    private void Start()
    {
        textMesh = sliceCountText.GetComponent<TextMesh>();
        textMesh.text = health.ToString();
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
        if (collision.CompareTag("Blade"))
        {
            enteredPosition = collision.attachedRigidbody.transform.position;
            isCollidingWithCursor = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Blade") && isCollidingWithCursor)
        {
            if (collision.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            isCollidingWithCursor = false;
            exitedPosition = collision.attachedRigidbody.transform.position;
            sliceLength = (exitedPosition - enteredPosition).magnitude;
            //Debug.Log(sliceLength);
            if (sliceLength > minSliceLength)
            {
                this.transform.localScale = hitShapeScale;
                health--;
                textMesh.text = health.ToString();
            }
            if (health < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void SetShapeLife(int health)
    {
        this.health = health;
    }
}
