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
    Vector3 randomSpawn;


    private void Start()
    {
        randomSpawn = new Vector3(Random.Range(650, 1250), Random.Range(300, 100), 0);
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
                Instantiate(cardPrefab, randomSpawn, Quaternion.identity, mainArea);
            }

        }
    }
}
