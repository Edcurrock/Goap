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
    public List<GAction> actions = new List<GAction>();
    public Dictionary<SubGoal,int> goals = new Dictionary<SubGoal, int>();
    public WorldStates beliefs = new WorldStates();
    
    GPlanner planner;
    Queue<GAction> actQueue;
    public GAction currentAction;
    SubGoal currentGoal;
    bool invoked = false;

    // Start is called before the first frame update
    public void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();
        foreach(GAction act in acts)
        {
             actions.Add(act);
        }
    }

    void CompleteAction()
    {
        currentAction.running = false;
        currentAction.PostPerform();
        invoked = false;
    }
  
    void LateUpdate()
    {
        if(currentAction!= null && currentAction.running)
        {
            if(currentAction.agent.hasPath && currentAction.agent.remainingDistance < 1f)
            {
                if(!invoked)
                {
                    Invoke("CompleteAction",currentAction.duration);
                    invoked = true;
                }
            }
            return; 
        }

        if(planner == null && actQueue == null)  
        {
            planner = new GPlanner();
            var sortedQGoals = from entry in goals orderby entry.Value descending select entry;
            foreach(KeyValuePair<SubGoal,int> sGoal in sortedQGoals)
            {
                actQueue = planner.Plan(actions,sGoal.Key.sgoals,null);
                if(actQueue != null)
                {
                    currentGoal = sGoal.Key;
                    break;
                }
            }
        } 
        if(actQueue != null && actQueue.Count == 0)
        {
            if(currentGoal.remove)
            {
                goals.Remove(currentGoal);
            }
            planner = null;
        }

        if(actQueue != null && actQueue.Count > 0)
        {
            currentAction = actQueue.Dequeue();
            if(currentAction.PrePerform())
            {
                if(currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }

                if(currentAction.target!= null)
                {
                     currentAction.running = true;
                     currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            else
            {
                actQueue = null;
            }
        }
    }
}
