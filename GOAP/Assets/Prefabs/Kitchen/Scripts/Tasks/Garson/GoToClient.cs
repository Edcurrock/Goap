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

        // resource = GWorld.Instance.GetQueue("tables").RemoveResource();
        // if (resource != null)
        // {
        //     inventory.AddItem(resource);
        // }
        // else
        // {
        //     GWorld.Instance.GetQueue("clients").AddResource(target);
        //     target = null;
        //     return false;
        // }

        //GWorld.Instance.GetWorld().ModifyState("FreeTable", -1);
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
