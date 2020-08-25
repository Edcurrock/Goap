using UnityEngine;

public class TestDoc : GAgent {

    new void Start() {

        // Call base Start method
        base.Start();
        SubGoal s1 = new SubGoal("repeat", 1, false);
        goals.Add(s1, 3);
    }

}