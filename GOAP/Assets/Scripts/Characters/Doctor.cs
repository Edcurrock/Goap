using UnityEngine;

public class Doctor : GAgent {

    new void Start() {

        // Call base Start method
        base.Start();
        SubGoal s1 = new SubGoal("relaxing", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("research", 1, false);
        goals.Add(s2, 1);
        InvokeRepeating("GetTired", Random.Range(15, 30), Random.Range(10, 20));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
    }
}