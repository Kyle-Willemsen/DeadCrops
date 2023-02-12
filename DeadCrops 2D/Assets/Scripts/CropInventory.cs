using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class CropInventory : MonoBehaviour, IDropHandler, IDragHandler
{
    GameObject droppedCard;
    DragDrop dragDrop;

    public void OnDrag(PointerEventData eventData)
    {
        if (transform.parent.tag == "Lawn")
        {
            Debug.Log("GreenLawn");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.parent.tag == "Crops" && transform.childCount == 0)
        {
            droppedCard = eventData.pointerDrag;
            dragDrop = droppedCard.GetComponent<DragDrop>();
            dragDrop.parentAfterDrag = transform;
            Instantiate(dragDrop.crop, dragDrop.parentAfterDrag.transform);
            dragDrop.gameObject.SetActive(false);
            Destroy(dragDrop.gameObject, 1f);
        }

        if (transform.parent.tag == "Lawn")// && transform.childCount == 0)
        {
            Debug.Log("PLSWORK");
            droppedCard = eventData.pointerDrag;
            dragDrop = droppedCard.GetComponent<DragDrop>();
            dragDrop.parentAfterDrag = transform;
            Instantiate(dragDrop.weaponAbility, dragDrop.parentAfterDrag.transform);
            Destroy(dragDrop.gameObject);
        }
    }

 
}
