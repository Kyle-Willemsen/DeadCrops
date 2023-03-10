using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI tmProCurrency;
    public float currentCurrency;
    CropButton cropButton;
    public GameObject pauseScreen;
    bool isPaused;
    public GameObject loseScreen;
    public DayNightCycle dayNight;



    private void Start()
    {
        isPaused = false;
    }
    public void Update()
    {
        tmProCurrency.text = "$" + currentCurrency;
        if (currentCurrency <= 0)
        {
            currentCurrency = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        isPaused = false;
    }
    public void ReduceCurrency(float cost)
    {
        currentCurrency -= cost;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}