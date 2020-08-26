using UnityEngine;

public class Nurse : GAgent {

    new void Start() {

        // Call base Start method
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("relaxing", 1, false);
        goals.Add(s2, 2);

        InvokeRepeating("GetTired",Random.Range(15,30),Random.Range(10,20));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
    }
}