using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  

public class SubGoal
{
    public Dictionary<string,int> sgoals;
    public bool remove;

    public SubGoal(string key, int value, bool rmv)
    {
        sgoals = new Dictionary<string, int>();
        sgoals.Add(key,value);
        remove = rmv;
    }
}

public class GAgent : MonoBehaviour
{
    List<GAction> actions = new List<GAction>();
    Dictionary<SubGoal,int> goals = new Dictionary<SubGoal, int>();

    GPlanner planner;
    Queue<GAction> actQueue;
    public GAction currentAction;
    SubGoal currentGoal;

    // Start is called before the first frame update
    void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();
        foreach(GAction act in acts)
        {
             actions.Add(act);
        }
    }

  
    void LateUpdate()
    {
        
    }
}
