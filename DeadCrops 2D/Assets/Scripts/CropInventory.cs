using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class CropInventory : MonoBehaviour, IDropHandler
{
    private GameObject droppedCard;
    DragDrop dragDrop;


    public void OnDrop(PointerEventData eventData)
    {
        if (transform.parent.tag == "Crops")
        {
            if (transform.childCount == 0)
            {
                droppedCard = eventData.pointerDrag;
                dragDrop = droppedCard.GetComponent<DragDrop>();
                dragDrop.parentAfterDrag = transform;
                Instantiate(dragDrop.crop, dragDrop.parentAfterDrag.transform);
                //Debug.Log(dragDrop);
                dragDrop.gameObject.SetActive(false);
                Destroy(dragDrop.gameObject, 1f);
                //Debug.Log("cropInventory");
            }
        }

        if (gameObject.tag == "Carrot" && transform.tag == "Carrot")
        {
            droppedCard = eventData.pointerDrag;
            dragDrop = droppedCard.GetComponent<DragDrop>();
            Debug.Log(dragDrop.parentAfterDrag.transform);
            dragDrop.parentAfterDrag = transform;
            dragDrop.stackable = true;
            dragDrop.parentAfterDrag = dragDrop.stackPosition;
        }
    }
}
