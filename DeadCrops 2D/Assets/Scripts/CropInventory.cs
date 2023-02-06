using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class CropInventory : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //if (transform.parent.tag == "Crops")
        //{
        if (transform.childCount == 0)
        {
            GameObject droppedCard = eventData.pointerDrag;
            DragDrop dragDrop = droppedCard.GetComponent<DragDrop>();
            dragDrop.parentAfterDrag = transform;
            Debug.Log("draggableItem");
        }

        //}
    }
}
