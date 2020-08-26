using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToilet : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveToilet();
        if(target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet", -1);
        return true;
    }
     
    public override bool PostPerform()
    {
        beliefs.RemoveState("needToilet");
        GWorld.Instance.AddToilet(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet", 1);
        return true;
    }

}
