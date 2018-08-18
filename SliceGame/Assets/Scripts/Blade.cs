using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

    public GameObject bladeTrailPrefab;

    private GameObject currentBladeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    bool isCutting = false;
    float trailLifeTime = 2f;
    Vector2 previousPosition;
    float minCuttingVelocity = 0.001f;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update () {
        if(Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCutting();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopCutting();
            }

            if (isCutting)
            {
                UpdateCut();
            }
        }
	}

    void StartCutting()
    {
        isCutting = true;
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rb.position;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, trailLifeTime);
        circleCollider.enabled = false;
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }
}
