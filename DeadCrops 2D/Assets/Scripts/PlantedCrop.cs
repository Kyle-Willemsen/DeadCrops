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
    DayNightCycle cycle;
    public Image finishedImage;
    public Image cooldownImage;
    public bool harvestAllButton;


    private void Start()
    {
        finishedImage.enabled = false;
        manager = FindObjectOfType<Manager>();
        cycle = FindObjectOfType<DayNightCycle>();
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
        if (cycle.endOfDay == true)
        {
            cropIsReady = true;
            Harvest();
        }
        if (harvestAllButton)
        {
            Harvest();
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
            manager.currentCurrency += cropRevenue;
            Destroy(gameObject);
            cropIsReady = false;
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
