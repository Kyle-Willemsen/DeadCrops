using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayNightCycle : MonoBehaviour
{
    public DayNightSlider slider;
    public Manager manager;
    public GameObject winScreen;
    EnemySpawner enemySpawner;
    
    public float timeInDay;
    public float currentTime;
    public bool dayOver;
    public float currentDay;
    public TextMeshProUGUI day;
    public bool endOfDay;

    public float initialSpawnTime;
    public float initialSpawnCounter;

    public float endOfDayEarlings;


    public void Start()
    {
        initialSpawnCounter = initialSpawnTime;
        endOfDay = false;
        enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        slider.SetMax(timeInDay);
        dayOver = false;
    }

    private void Update()
    {
        day.text = "Day: " + currentDay;
        currentTime = currentTime + 1 * Time.deltaTime;
        slider.SetCurrent(currentTime);
       

        if (currentTime >= timeInDay)
        {
            dayOver = true;
            enemySpawner.canSpawn = false;
            if (enemySpawner.enemyCounter <= 0)
            {
               DayOver();
            }
        }
        else
        {
            dayOver = false;
        }

        if (currentDay >= 5)
        {
            enemySpawner.maxSpawnTime = 8;
            enemySpawner.minSpawntime = 3;
            enemySpawner.enemyTypeCounter = 6;
            endOfDayEarlings = 50;
        }
        if (currentDay >= 10)
        {
            enemySpawner.maxSpawnTime = 8;
            enemySpawner.minSpawntime = 0;
            enemySpawner.enemyTypeCounter = 9;
            endOfDayEarlings = 100;
        }
        if (currentDay >= 15)
        {
            enemySpawner.maxSpawnTime = 5;
            enemySpawner.minSpawntime = 0;
            enemySpawner.enemyTypeCounter = 14;
            endOfDayEarlings = 150;
        }

       
        
            initialSpawnCounter = initialSpawnCounter -1 * Time.deltaTime;
            if (initialSpawnCounter <= 0)
            {
                initialSpawnCounter = 0;
            }
        
    }

    public void DayOver()
    {
        currentTime = timeInDay;
        //enemySpawner.canSpawn = false;
        winScreen.SetActive(true);
        Time.timeScale = 0;
        endOfDay = true;
        
    }
    public void NewDay()
    {
        enemySpawner.enemyTypeCounter++;
        winScreen.SetActive(false);
        Time.timeScale = 1;
        enemySpawner.canSpawn = true;
        currentDay++;
        timeInDay = timeInDay + 5;
        currentTime = 0;
        dayOver = false;
        slider.SetMax(timeInDay);
        endOfDay = false;
        initialSpawnCounter = initialSpawnTime;
        manager.currentCurrency += endOfDayEarlings;
    }
}
