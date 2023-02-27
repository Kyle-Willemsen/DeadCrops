using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class House : MonoBehaviour
{
    private float amountOfLives = 5;
    public float currentAmountOfLives;
    public TextMeshProUGUI lives;
    public Manager manager;


    private void Start()
    {
        currentAmountOfLives = amountOfLives;
    }

    private void Update()
    {
        lives.text = "Lives:  " + currentAmountOfLives;
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
