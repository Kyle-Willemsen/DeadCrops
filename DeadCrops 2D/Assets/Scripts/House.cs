using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private float amountOfLives = 5;
    public float currentAmountOfLives;

    public Manager manager;


    private void Start()
    {
        currentAmountOfLives = amountOfLives;
    }

    private void Update()
    {
        if (currentAmountOfLives <= 0)
        {
            manager.LoseScreen();
        }
        else
        {
            //manager.ResetGame();
        }
    }
    public void TakeALife(float life)
    {
        currentAmountOfLives -= life;
    }
}
