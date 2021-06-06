using UnityEngine;

public class Garson : GAgent
{
    [SerializeField] float time  = 5f;
    DifficultyManager manager;
    new void Start()
    {
        base.Start();
        manager = GameObject.FindGameObjectWithTag("Difficulty").GetComponent<DifficultyManager>();
        InvokeRepeating("NeedToilet", time, time);

        SubGoal s1 = new SubGoal("waiting", 1, false);
        goals.Add(s1, 1);

        SubGoal s2 = new SubGoal("goToClient", 1, false);
        goals.Add(s2, 2);

        SubGoal s3 = new SubGoal("servedClient", 1, false);
        goals.Add(s3, 3);

        SubGoal s4 = new SubGoal("goRest", 1, false);
        goals.Add(s4, 4);
    }

    void NeedToilet()
    {
        var chance = Random.Range(0f,1f);
        if(chance <= manager.RestChance)
        { 
            beliefs.ModifyState("needToilet", 0);
        }
    }
}