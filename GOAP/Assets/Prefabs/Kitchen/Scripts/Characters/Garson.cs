using UnityEngine;

public class Garson : GAgent
{
    new void Start()
    {
        // Call base Start method
        base.Start();
        SubGoal s1 = new SubGoal("waiting", 1, false);
        goals.Add(s1, 1);

        SubGoal s2 = new SubGoal("goToClient", 1, false);
        goals.Add(s2, 2);

        SubGoal s3 = new SubGoal("servedClient", 1, false);
        goals.Add(s3, 3);
    }
}