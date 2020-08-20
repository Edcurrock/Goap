using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class Node
{
    public Node parent;
    public float cost;
    public Dictionary<string,int> state;
    public GAction action;

    public Node(Node parent, float cost, Dictionary<string,int> allStates, GAction action)
    {
        this.parent = parent;
        this.cost = cost;
        this.state = new Dictionary<string, int>(allStates);
        this.action = action;
    }
}

public class GPlanner
{
    public Queue<GAction> Plan(List<GAction> actions, Dictionary<string,int> goal, WorldStates states)
    {
        List<GAction> usableActions = new List<GAction>();
        foreach(var act in actions)
        {
            if(act.IsAchievable())
                usableActions.Add(act);
        }

        List<Node> leaves = new List<Node>();
        Node start = new Node(null,0,GWorld.Instance.GetWorld().GetStates(), null);

        bool success = BuildGraph(start, leaves, usableActions, goal);  
        if(!success)
        {
            Debug.Log("No Plan!");
            return null;
        }

        Node cheapest = null;
        foreach(Node leaf in leaves)
        {
            if(cheapest == null)
                cheapest = leaf;
            else
            {
                if(leaf.cost < cheapest.cost)
                    cheapest = leaf;
            }
        }
        List<GAction> result = new List<GAction>();
        Node n = cheapest;
        while(n!= null)
        {
            if(n.action != null)
            {
                result.Insert(0, n.action);
            }
            n = n.parent;
        }

        Queue<GAction> queue = new Queue<GAction>();
        foreach(GAction act in result)
        {
            queue.Enqueue(act);
        }

        Debug.Log("Plan is: ");
        foreach(var q in queue)
        {
            Debug.Log("Q: " + q.actionName);
        }

        return queue;
    }   

    bool BuildGraph(Node parent, List<Node> leaves, List<GAction> usableActions, Dictionary<string,int> goal)
    {
        bool foundPath = false;
        foreach(var act in usableActions)
        {
            if(act.IsAchievableGiven(parent.state))
            {
                Dictionary<string,int> currentState = new Dictionary<string, int>(parent.state);
                foreach(KeyValuePair<string, int> eff in act.effects)
                {
                    if(!currentState.ContainsKey(eff.Key))
                        currentState.Add(eff.Key,eff.Value);
                }
                Node node = new Node(parent, parent.cost + act.cost, currentState, act);

                if(GoalAchieved(goal, currentState))
                {
                    leaves.Add(node);
                    foundPath = true;
                }
                else
                {
                    List<GAction> subset = ActionSubset(usableActions,act);
                    bool found  = BuildGraph(node, leaves, subset, goal);
                    if(found)
                    {
                        foundPath = true;
                    }
                }
            }
        }
        return foundPath;
    }

    private List<GAction> ActionSubset(List<GAction> usableActions, GAction removeMe)
    {
        List<GAction> subset = new List<GAction>();
        foreach(GAction a in usableActions)
        {
            if(!a.Equals(removeMe))
            {
                subset.Add(a);
            }
        }
        return subset;
    }

    private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> currentState)
    {
        foreach(KeyValuePair<string,int> g in goal)
        {
            if(!currentState.ContainsKey(g.Key))
            {
                return false;
            }
        }
        return true;
    }
}