using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public delegate void DifficultyAction();
    public event DifficultyAction difficultyAct;
    [SerializeField] GameObject menuObject;
    
    bool isActive = true;
    float timeScale;
    // Start is called before the first frame update
    private void Start() 
    {
        timeScale = Time.timeScale;
        isActive = menuObject.active;
    }


    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            menuObject.SetActive(isActive);
            if(isActive == false)
            {
                Time.timeScale = timeScale;
                OnDifficulty();
            }
            else
            {
                timeScale = Time.timeScale;
                Time.timeScale = 0;
            }
        }
    }


    public void OnDifficulty()
    {
        difficultyAct.Invoke();
    }

   
}
