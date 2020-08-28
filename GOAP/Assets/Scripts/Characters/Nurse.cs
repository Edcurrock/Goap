using UnityEngine;

public class Nurse : GAgent {

    new void Start() {

        // Call base Start method
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("relaxing", 1, false);
        goals.Add(s2, 2);

        SubGoal s3 = new SubGoal("toilet", 1, false);
        goals.Add(s3, 4);

        InvokeRepeating("GetTired",Random.Range(15,30),Random.Range(10,20));
        InvokeRepeating("NeedToilet", Random.Range(50, 60), Random.Range(70, 80));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
    }

    void NeedToilet()
    {
        beliefs.ModifyState("needToilet", 0);
    }
}