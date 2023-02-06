using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI tmProCurrency;
    public float currentCurrency;
    CropButton cropButton;


    private void Start()
    {

    }

    public void Update()
    {
        tmProCurrency.text = "" + currentCurrency;
        if (currentCurrency <= 0)
        {
            currentCurrency = 0;
        }
    }

    public void ReduceCurrency(float cost)
    {
        Debug.Log("$20");
        currentCurrency -= cost;
    }
}
