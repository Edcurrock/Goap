using UnityEngine;

public class Janitor : GAgent {

    new void Start() {

        // Call the base start
        base.Start();
        // Set up the subgoal "isWaiting"
        SubGoal s1 = new SubGoal("cleaned", 1, false);
        goals.Add(s1,1);

        SubGoal s2 = new SubGoal("relax", 1, false);
        goals.Add(s2, 2);
        InvokeRepeating("GetTired", Random.Range(70, 80), Random.Range(60, 70));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
    }
}