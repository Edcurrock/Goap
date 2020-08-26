using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePuddle();
        if(target == null)
            return false;
        return true;
    }
     
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Puddles",-1);
        Destroy(target);
        return true;
    }

}
