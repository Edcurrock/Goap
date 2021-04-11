using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    [Range(0f, 1f)] 
    [SerializeField] float treatChance = 0.5f; 
    [SerializeField] Slider slider;

    [SerializeField] int winScore = 8;
    [SerializeField] Text gameStatusText;

    [SerializeField] TimeManager timeManager;

    private void Start() 
    {
        if(timeManager)
            timeManager.gameOvetTime += GameStatus;
    }
    public int CurrentScore
    {
        get;
        set; 
    }

    public float TreatChance
    {
        get { return treatChance; }
    }

    public void ChangeChance()
    {
        treatChance = slider.value;
    }

    public void GameStatus()
    {
        gameStatusText.gameObject.SetActive(true);
        if(CurrentScore >= winScore)
            gameStatusText.text = "WIN";
        else
            gameStatusText.text = "FAILED";

    }
}