using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public GameObject controller;
    bool ActiveWhite = true;
    float currentTimeBlack;
    float currentTimeWhite;
    public int MinutesBlack;
    public int MinutesWhite;
    public Text CurrentTimeBlackText;
    public Text CurrentTimeWhiteText;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeBlack = MinutesBlack * 60;
        currentTimeWhite = MinutesWhite * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveWhite == true)
        {
            currentTimeWhite -= Time.deltaTime;
        }
        else
        {
            currentTimeBlack -= Time.deltaTime;
        }
        if (currentTimeWhite <= 0)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
            currentTimeWhite = 0;
            controller.GetComponent<Game>().Winner("Black");
        }
        if (currentTimeBlack <= 0)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
            currentTimeBlack = 0;
            controller.GetComponent<Game>().Winner("White");
        }
        TimeSpan timeBlack = TimeSpan.FromSeconds(currentTimeBlack);
        TimeSpan timeWhite = TimeSpan.FromSeconds(currentTimeWhite);
        CurrentTimeBlackText.text = timeBlack.Minutes.ToString() + ":" + timeBlack.Seconds.ToString();
        CurrentTimeWhiteText.text = timeWhite.Minutes.ToString() + ":" + timeWhite.Seconds.ToString();
    }

    public void StartWhite()
    {
        ActiveWhite = true;  
    }
    
    public void StartBlack()
    {
        ActiveWhite = false;
    }

}
