using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image image;
    public Image image2;
    Vector3 dragScale;
    Vector3 originalScale;
    [HideInInspector] public Transform parentAfterDrag;
    public GameObject crop;
    public GameObject weaponAbility;
    public bool stackable;
    public Vector3 worldPosition;
    //public Transform stackPosition;
    public bool growable;


    private void Start()
    {
        originalScale = new Vector3(1, 1, 1);
        dragScale = new Vector3(1.1f, 1.1f, 1.1f);
        parentAfterDrag = transform.parent;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        image2.raycastTarget = false;

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        gameObject.transform.localScale = dragScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.localScale = originalScale;
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        image2.raycastTarget = true;
    }
}
