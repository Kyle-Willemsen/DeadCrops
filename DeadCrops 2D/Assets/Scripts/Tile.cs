using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color baseColour, offsetColour;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] GameObject highlight;
    [SerializeField] 

    public void Init(bool isOffset)
    {
        renderer.color = isOffset ? offsetColour : baseColour;
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
        if (gameObject.tag == "Lawn")
        {
            
        }
    }
}
