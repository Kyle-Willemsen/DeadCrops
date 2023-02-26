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
    //public bool stackable;
    //public Vector3 worldPosition;
    //public Transform stackPosition;
    public bool growable;
    public GameObject backside;
    private bool backsideActive;



    private void Start()
    {
        originalScale = new Vector3(1.2f, 1.2f, 1.2f);
        dragScale = new Vector3(1.3f, 1.3f, 1.3f);
        parentAfterDrag = transform.parent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !backsideActive)
        {
            backside.SetActive(true);
            backsideActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && backsideActive)
        {
            backside.SetActive(false);
            backsideActive = false;
        }
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
