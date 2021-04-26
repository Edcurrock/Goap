using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float gameOverTime = 180f;
    [SerializeField] Text timerText;


    public delegate void GameOverAction();
    public event GameOverAction gameOverAction;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ShowTime();
        gameOverTime -= Time.deltaTime;
        if(gameOverTime <= 0)  
        {
            GameOver();
            gameOverTime = 0;
        }
    
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameOverAction.Invoke();
        
    }

    void ShowTime()
    {
        int minutes = Mathf.FloorToInt(gameOverTime / 60);
        int seconds = Mathf.FloorToInt(gameOverTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
