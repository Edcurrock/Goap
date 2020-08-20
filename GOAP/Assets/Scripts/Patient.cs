using UnityEngine;

public class Patient: GAgent
{
    private void Start() 
    {
        base.Start();
        SubGoal s1 = new SubGoal("isWaiting", 1, true);
        goals.Add(s1,3);
    }
}