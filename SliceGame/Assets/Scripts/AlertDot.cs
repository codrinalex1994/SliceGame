using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDot : MonoBehaviour
{

    private Color alertColor;
    private Color actualColor;
    private float selfDestroySeconds = 3f;
    private SpriteRenderer spriteRenderer;
    private float lerpFactor = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        actualColor = spriteRenderer.color;
        alertColor = Color.red;
    }

    void Update()
    {
        spriteRenderer.color = Color.Lerp(actualColor, alertColor, lerpFactor);
        if (lerpFactor < 1)
        {
            lerpFactor += Time.deltaTime / selfDestroySeconds;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Destroy(this.gameObject);
        }
    }
}