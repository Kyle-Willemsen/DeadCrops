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


    private void Start()
    {

    }

    public void Purchase()
    {
        if (cost <= gameManager.currentCurrency)
        {
        gameManager.currentCurrency -= cost;
            Instantiate(cardPrefab, mainArea.position, Quaternion.identity, mainArea);
        }
    }
}
