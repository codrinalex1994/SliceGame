using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDot : MonoBehaviour {

    public GameObject dot;
    public float spawnDistanceX;
    public float spawnDistanceY;

    private Vector2 spawnPos;

    private float spawnTime = 4f;
    private float lastSpawnedTime;

    private int noOfDots = 2;

    private Color[] colors = { Color.green, Color.red, Color.blue, Color.yellow};
    private int currentColor;
    private List<GameObject> dotsSpawned;
    private bool dotsAreConnected = false;

    private void Start()
    {
        dotsSpawned = new List<GameObject>();
        lastSpawnedTime = Time.time;
        SetCurrentColor();
    }

    void Update () {
		if(Time.time > lastSpawnedTime + spawnTime)
        {
            if (!dotsAreConnected)
            {
                DeleteDots();
            }
            for(int i = 0; i < noOfDots; ++i)
            {
                SetSpawnPos();
                GameObject dotInst = Instantiate(dot, spawnPos, Quaternion.identity);
                AlertDot alertDot = dotInst.GetComponent<AlertDot>();
                alertDot.SetColor(colors[currentColor]);
                dotsSpawned.Add(dotInst);
            }
            lastSpawnedTime = Time.time;
            SetCurrentColor();
        }
	}

    void SetSpawnPos()
    {
        spawnPos.x = Random.Range(-spawnDistanceX, spawnDistanceX);
        spawnPos.y = Random.Range(-spawnDistanceY, spawnDistanceY);
    }

    public void SetNoOfDots(int noOfDots)
    {
        this.noOfDots = noOfDots;
    }

    private void SetCurrentColor()
    {
        currentColor = Random.Range(0, colors.Length);
    }

    private void DeleteDots()
    {
        while(dotsSpawned.Count != 0)
        {
            //Debug.Log(dotsSpawned.Count);
            GameObject oldDot = dotsSpawned[0];
            dotsSpawned.RemoveAt(0);
            Destroy(oldDot);
        }
        //Debug.Log(dotsSpawned.Count);
    }
}
