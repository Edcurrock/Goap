using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOut : GAction
{
    public delegate void PuddleAction();
    public event PuddleAction puddleAction;

    public override bool PrePerform()
    {
        GWorld.Instance.GetWorld().ModifyState("FreeTable", 1);
        GWorld.Instance.GetQueue("tables").AddResource(GetComponent<Visitor>().extTarget);
        GetComponent<Visitor>().extTarget = null;
        beliefs.ModifyState("served", -1);
        InitPuddle();
        return true;
    }

    public override bool PostPerform()
    {
        Destroy(gameObject);
        return true;
    }

    void InitPuddle()
    {
        var puddle = GameObject.FindWithTag("Spawn").GetComponent<Init>();
        puddle.InitPuddle(transform.position);
    }
}
