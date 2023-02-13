using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color baseColour, offsetColour;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject highlight;

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColour : baseColour;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseDrag()
    {
        
    }
}
