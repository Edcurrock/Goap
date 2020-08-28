using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToilet : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("toilets").RemoveResource();
        if(target == null)
            return false;
        //inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet", -1);
        return true;
    }
     
    public override bool PostPerform()
    {
        beliefs.RemoveState("needToilet");
        GWorld.Instance.GetQueue("toilets").AddResource(target);
        //inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet", 1);
        return true;
    }

    void InitPuddle()
    {
        var isPuddle = Random.Range(1,4);
        if(isPuddle == 1)
        {
            GameObject puddle = GameObject.Find("Init").GetComponent<Init>().puddle;
            var clone = Instantiate(puddle, transform.position, Quaternion.identity);
            GWorld.Instance.GetWorld().ModifyState("Puddles", 1);
            GWorld.Instance.GetQueue("puddles").AddResource(clone);
        }
    }
}
