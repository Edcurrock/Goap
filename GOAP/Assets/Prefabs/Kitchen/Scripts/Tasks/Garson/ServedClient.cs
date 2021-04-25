using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServedClient : GAction
{
    public override bool PrePerform()
    {
        target = GetComponent<Garson>().extTarget;
        if(target == null)
        {
            return false;
        }
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Served", 1);
        GetComponent<Garson>().extTarget = null;
        return true;
    }

}
