using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOut : GAction
{
    public override bool PrePerform()
    {
        GWorld.Instance.GetWorld().ModifyState("FreeTable", 1);
        beliefs.ModifyState("served", -1);
        return true;
    }

    public override bool PostPerform()
    {
        Destroy(gameObject);
        return true;
    }

}
