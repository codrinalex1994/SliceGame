using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsLerp : MonoBehaviour {

	public Color[] colors;

    private float transition;
    private int firstIndex;
    private int secondIndex;
    private Color lerpedColor;

    private void Start()
    {
        Debug.Log(colors.Length);
        firstIndex = 0;
        secondIndex = firstIndex + 1;
        transition = 0f;
    }

	public Color PickColor()
    {
        if(transition >= 1.0f)
        {
            transition = 0f;
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
        lerpedColor = Color.Lerp(colors[firstIndex], colors[secondIndex], transition);
        transition += 0.2f;
        return lerpedColor;
    }
}
