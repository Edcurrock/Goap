using UnityEngine;

public class Nurse : GAgent {

    new void Start() {

        // Call base Start method
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("relaxing", 1, false);
        goals.Add(s2, 3);
    }

    // private void Update() 
    // {
    //     if(!GWorld.Instance.GetWorld().GetStates().ContainsKey("Waiting"))
    //     {
    //         if(!GWorld.Instance.GetWorld().GetStates().ContainsKey("Relax"))
    //             GWorld.Instance.GetWorld().ModifyState("Relax",0);
    //     }
    //     else if(GWorld.Instance.GetWorld().GetStates().ContainsKey("Relax"))
    //     {
    //         GWorld.Instance.GetWorld().ModifyState("Relax",-1);
    //     }
    // }
}