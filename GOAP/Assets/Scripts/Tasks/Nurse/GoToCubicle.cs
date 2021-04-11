using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCubicle : GAction
{
    [SerializeField] DifficultyManager difficulty;
    [SerializeField] float treatChance;

    private void Start() 
    {
        difficulty = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyManager>();
        treatChance = difficulty.TreatChance;
        Menu menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        menu.difficultyAct += DifficultyChange;
    }
    
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if(target == null)
            return false;
        return true;
    }
     
    public override bool PostPerform()
    {
        var chance = Random.RandomRange(0f, 1f) <= treatChance ? true : false;
        if(chance)
        {
            GWorld.Instance.GetWorld().ModifyState("Success", 1);
            difficulty.CurrentScore ++;
        }
        else
            GWorld.Instance.GetWorld().ModifyState("Failed", 1);

        GWorld.Instance.GetWorld().ModifyState("TreatingPatient",1);
        GWorld.Instance.GetQueue("cubicles").AddResource(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle",1);
        return true;
    }

    public void DifficultyChange()
    {
        treatChance = difficulty.TreatChance;
    }

}
