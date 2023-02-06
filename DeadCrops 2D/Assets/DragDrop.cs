using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public Vector3 dragScale;
    public Vector3 originalScale;


    private void Start()
    {
        originalScale = new Vector3(1, 1, 1);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        gameObject.transform.localScale = dragScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.localScale = originalScale;
    }
}
