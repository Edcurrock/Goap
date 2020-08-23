public class Patient : GAgent {

    new void Start() {

        // Call the base start
        base.Start();
        // Set up the subgoal "isWaiting"
        SubGoal s1 = new SubGoal("isWaiting", 1, true);
        goals.Add(s1,3);

        SubGoal s2 = new SubGoal("isTreated", 1, true);
        goals.Add(s2, 5);
    }

}