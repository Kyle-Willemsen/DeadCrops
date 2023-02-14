using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
    private float maxWeaponSlots = 2;
    public float currentWeaponSlot;


    private void Start()
    {
        currentWeaponSlot = 0;
    }
    public void Purchase()
    {
        if (cost <= gameManager.currentCurrency)
        {
            if (gameObject.tag == "Weapons")
            {
                if (currentWeaponSlot <= maxWeaponSlots)
                {
                    currentWeaponSlot++;
                    Debug.Log("weaponTrans");
                    gameManager.currentCurrency -= cost;
                    Instantiate(cardPrefab, weaponSlots.position, Quaternion.identity, weaponSlots);
                    return;
                }
            }
            gameManager.currentCurrency -= cost;
            Instantiate(cardPrefab, mainArea.position, Quaternion.identity, mainArea);

        }
    }
}
