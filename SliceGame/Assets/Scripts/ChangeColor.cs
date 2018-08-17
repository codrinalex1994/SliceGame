using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    private Renderer rend;

    public GameObject gameObject;
    private ColorsLerp colorsLerp;

    [SerializeField]
    private Color colorToTurnTo = Color.white;

    //private float startTime;

	void Start () {

        colorsLerp = gameObject.GetComponent<ColorsLerp>();
        rend = GetComponent<Renderer>();

        ChangeTheColor();
    //    startTime = Time.time;
	}

    /*void Update()
    {
        if(Time.time > startTime + 1.0f)
        {
            startTime = Time.time;
            ChangeTheColor();
        }
    }*/

    void ChangeTheColor()
    {
        colorToTurnTo = colorsLerp.PickColor();
        rend.material.color = colorToTurnTo;
    }

}
