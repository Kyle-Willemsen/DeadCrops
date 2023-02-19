using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class CropButton : MonoBehaviour
{
    public Manager gameManager;
    public Image cropImage;
    public float cost;
    public GameObject cardPrefab;
    public Transform mainArea;
    public Transform weaponSlots;
    private float maxWeaponSlots = 3;
    public float currentWeaponSlot;


    private void Start()
    {
    }
    public void Purchase()
    {
        if (cost <= gameManager.currentCurrency)
        {
            if (gameObject.tag == "Weapons" && currentWeaponSlot < maxWeaponSlots)
            {
                    currentWeaponSlot++;
                    gameManager.currentCurrency -= cost;
                    Instantiate(cardPrefab, weaponSlots.position, Quaternion.identity, weaponSlots);
                    return;
                
            }
            else if (gameObject.tag == "Draggable")
            {
                gameManager.currentCurrency -= cost;
                Instantiate(cardPrefab, mainArea.position, Quaternion.identity, mainArea);
            }

        }
    }
}
