using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClient : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("clients").RemoveResource();
        GetComponent<Garson>().extTarget = target;
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Serve", -1);
        if (target)
        {
            target.GetComponent<GAgent>().inventory.AddItem(resource);
        }
        return true;
    }

}
