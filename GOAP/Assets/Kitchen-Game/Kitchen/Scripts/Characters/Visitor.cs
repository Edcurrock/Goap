using UnityEngine;

public class Visitor : GAgent
{
    new void Start()
    {
        // Call base Start method
        base.Start();

        SubGoal s3 = new SubGoal("goToTable", 1, true);
        goals.Add(s3, 3);

        // SubGoal s4 = new SubGoal("served", 1, true);
        // goals.Add(s4, 4);

        SubGoal s5 = new SubGoal("goOut", 1, true);
        goals.Add(s5, 5);
    }
}