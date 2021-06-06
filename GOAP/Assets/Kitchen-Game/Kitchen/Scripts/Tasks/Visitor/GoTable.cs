using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTable : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("tables").RemoveResource();
        GetComponent<Visitor>().extTarget = target;
        if (target == null)
            return false;

        GWorld.Instance.GetWorld().ModifyState("FreeTable", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Serve", 1);
        GWorld.Instance.GetQueue("clients").AddResource(this.gameObject);
        return true;
    }

}
