public class Janitor : GAgent {

    new void Start() {

        // Call the base start
        base.Start();
        // Set up the subgoal "isWaiting"
        SubGoal s1 = new SubGoal("cleaned", 1, false);
        goals.Add(s1,2);

        SubGoal s2 = new SubGoal("relax", 1, false);
        goals.Add(s2, 1);
    }

}