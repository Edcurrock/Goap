using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init: MonoBehaviour
{
    public GameObject puddle;
    DifficultyManager difficultyManager;
    private void Start() 
    {
        difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
        Menu menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        menu.difficultyAct += ChangeChance;
    }

    public float chance = 0.25f;
    public void InitPuddle(Vector3 position)
    {
        var puddleChance = Random.Range(0f, 1f);
        if (puddleChance <= chance)
        {
            var clone = Instantiate(puddle, position, Quaternion.identity);
            GWorld.Instance.GetWorld().ModifyState("Puddles", 1);
            GWorld.Instance.GetQueue("puddles").AddResource(clone);
          //  puddleAction.Invoke();
        }
    }

    void ChangeChance()
    {
        chance = difficultyManager.PuddleChance;
    }
}
