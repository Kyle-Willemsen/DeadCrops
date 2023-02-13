using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantedCrop : MonoBehaviour
{
    public float growTime;
    public float growtimer;
    public bool cropIsReady;
    public float cropRevenue;
    Manager manager;
    public Image finishedImage;
    public Image cooldownImage;


    private void Start()
    {
        finishedImage.enabled = false;
        manager = FindObjectOfType<Manager>();
        cropIsReady = false;
        Grow();

    }

    public void Update()
    {
        if (growtimer > 0)
        {
            growtimer -= Time.deltaTime;
        }

        if (growtimer <= 0)
        {
            ResetTimer();
        }
    }

    public void Grow()
    {
        growtimer = growTime;
    }


    public void Harvest()
    {
        if (cropIsReady)
        {
            cropIsReady = false;
            manager.currentCurrency += cropRevenue;
            Destroy(gameObject);
        }

    }

    private void ResetTimer()
    {
        finishedImage.enabled = true;
        cooldownImage.enabled = false;
        cropIsReady = true;
        growtimer = 0f;
    }
}
