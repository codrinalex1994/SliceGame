using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDot : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Destroy(this.gameObject);
        }
    }

    public void SetColor(Color color)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }
}