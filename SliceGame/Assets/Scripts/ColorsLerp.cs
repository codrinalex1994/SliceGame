using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsLerp : MonoBehaviour {

	public Color[] colors;

    private float transitionLerp;
    private float transitionLerpInc = 0.3f;
    private int firstIndex;
    private int secondIndex;
    private Color lerpedColor;

    private void Start()
    {
        //Debug.Log(colors.Length);
        firstIndex = 0;
        secondIndex = firstIndex + 1;
        transitionLerp = 0f;
    }

	public Color PickColor()
    {
        if(transitionLerp >= 1.0f)
        {
            transitionLerp = 0f;
            firstIndex++;
            if(firstIndex == colors.Length)
            {
                firstIndex = 0;
            }
            secondIndex = firstIndex + 1;
            if(secondIndex == colors.Length)
            {
                secondIndex = 0;
            }

        }
        lerpedColor = Color.Lerp(colors[firstIndex], colors[secondIndex], transitionLerp);
        transitionLerp += transitionLerpInc;
        return lerpedColor;
    }
}
