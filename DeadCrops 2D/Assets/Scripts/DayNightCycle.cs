using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    public DayNightSlider slider;
    public float timeInDay;
    public float currentTime;
    public Manager manager;
    public bool dayOver;


    public void Start()
    {
        slider.SetMax(timeInDay);
        dayOver = false;
    }

    private void Update()
    {
        currentTime = currentTime + 1 * Time.deltaTime;
        slider.SetCurrent(currentTime);


        if (currentTime >= timeInDay)
        {
            currentTime = timeInDay;
            dayOver = true;
        }
        else
        {
            dayOver = false;
        }
    }
}
