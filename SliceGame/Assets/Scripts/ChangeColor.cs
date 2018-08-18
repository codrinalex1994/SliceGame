using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    private Renderer rend;

    public GameObject colorKeeper;
    private ColorsLerp colorsLerp;

    [SerializeField]
    private Color colorToTurnTo = Color.white;

	void Start () {
        if(colorKeeper == null)
        {
            colorKeeper = GameObject.FindWithTag("ColorKeeper");
        }
        colorsLerp = colorKeeper.GetComponent<ColorsLerp>();
        rend = GetComponent<Renderer>();

        ChangeTheColor();
	}

    void ChangeTheColor()
    {
        colorToTurnTo = colorsLerp.PickColor();
        rend.material.color = colorToTurnTo;
    }

}
