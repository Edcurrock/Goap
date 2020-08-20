using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "SimpleAction";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0f; 
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string,int> preconditions;
    public Dictionary<string,int> effects;
    
    public WorldState agentBeliefs;
    public bool running = false;

    public GAction()
    {
        preconditions = new Dictionary<string,int>();
        effects = new Dictionary<string, int>();

    }

    private void Awake() 
    {
        agent = this.GetComponent<NavMeshAgent>();
        if(preConditions != null)
        {
            foreach(WorldState wState in preConditions)
            {
                preconditions.Add(wState.key,wState.value);
            }
        }

        if (afterEffects != null)
        {
            foreach (WorldState wState in afterEffects)
            {
                effects.Add(wState.key, wState.value);
            }
        }
    }


    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string,int> conditions)
    {
        foreach(KeyValuePair<string,int> pair in preconditions)
        {
            if(!conditions.ContainsKey(pair.Key)) 
                return false;
        }   
        return true;
    }
  
  public abstract bool PrePerform();
  public abstract bool PostPerform();
}
