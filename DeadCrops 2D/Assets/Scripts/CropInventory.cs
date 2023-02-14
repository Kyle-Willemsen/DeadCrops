using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class CropInventory : MonoBehaviour, IDropHandler
{
    GameObject droppedCard;
    DragDrop dragDrop;


    public void OnDrop(PointerEventData eventData)
    {
        droppedCard = eventData.pointerDrag;
        dragDrop = droppedCard.GetComponent<DragDrop>();

        if (transform.parent.tag == "Crops" && transform.childCount == 0 && dragDrop.growable)
        {
            dragDrop.parentAfterDrag = transform;
            Instantiate(dragDrop.crop, dragDrop.parentAfterDrag.transform);
            dragDrop.gameObject.SetActive(false);
            Destroy(dragDrop.gameObject, 1f);
        }

        if (transform.parent.tag == "Lawn" && transform.childCount == 0)
        {
            dragDrop.parentAfterDrag = transform;
            Instantiate(dragDrop.weaponAbility, dragDrop.parentAfterDrag.transform);
            Destroy(dragDrop.gameObject);
        }
        return;
    }
 
}
