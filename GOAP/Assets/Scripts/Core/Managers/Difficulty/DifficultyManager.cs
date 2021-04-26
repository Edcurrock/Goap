using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    [Range(0f, 1f)] 
    [SerializeField] float treatChance = 0.5f; 
    
    [Range(0f, 1f)] 
    [SerializeField] float puddlesChance = 0.25f; 

    [SerializeField] Slider slider;

    [SerializeField] Slider sliderPuddle;

    [SerializeField] int winScore = 8;
    [SerializeField] Text gameStatusText;

    [SerializeField] TimeManager timeManager;

    [SerializeField] Init initManager;

    //////////Character Inpit Field////////
    ///GARSON///
    [SerializeField] InputField prepareFoodField;
    [SerializeField] InputField takeOrderField;
    ///Visitor//
    [SerializeField] InputField MakeOrderField;
    [SerializeField] InputField RegisterField;
    ////////////Characters///////////
    Garson[] garsons;
    Visitor[] visitors;

    private void Start() 
    {
        FindAllGarsons();
        FindAllVisitors();

        if(timeManager)
        {
            timeManager.gameOverAction += GameStatus;
        }

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

    public float PuddleChance
    {
        get { return puddlesChance; }
    }

    public void ChangeChance()
    {
        treatChance = slider.value;
    }

    public void ChangePuddleChance()
    {
        puddlesChance = sliderPuddle.value;
    }

    public void GameStatus()
    {
        gameStatusText.gameObject.SetActive(true);
        if(CurrentScore >= winScore)
            gameStatusText.text = "WIN";
        else
            gameStatusText.text = "FAILED";

    }

    public void ChangeGarsonSpeed()
    {
        foreach (var item in garsons)
        {
            item.GetComponent<NavMeshAgent>().speed = 1;
        }
    }

    public void FindAllGarsons()
    {
        garsons = GameObject.FindObjectsOfType<Garson>();
    }

    public void FindAllVisitors()
    {
        visitors = GameObject.FindObjectsOfType<Visitor>();
    }

    /// GARSON ///
    public void ChangeGarsonFoodPrepareTime()
    {
        foreach (var item in garsons)
        {
            var text = prepareFoodField.text;
            float result;
            if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out result))
            {
                item.GetComponent<GoToKitchen>().duration = result;
            }
        }
    }

    public void ChangeTakeOrderTime()
    {
        foreach (var item in garsons)
        {
            var text = takeOrderField.text;
            float result;
            if(float.TryParse(text,NumberStyles.Float,CultureInfo.InvariantCulture.NumberFormat, out result))
            {
                item.GetComponent<GoToClient>().duration = result;
            }
        }
    }

    /// Visitor ///
    public void MakeOrderTime()
    {
        foreach (var item in visitors)
        {
            var text = MakeOrderField.text;
            float result;
            if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out result))
            {
                item.GetComponent<GoTable>().duration = result;
            }
        }
    }

    public void RegisterTime()
    {
        foreach (var item in visitors)
        {
            var text = RegisterField.text;
            float result;
            if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out result))
            {
                item.GetComponent<Register>().duration = result;
            }
        }
    }

}