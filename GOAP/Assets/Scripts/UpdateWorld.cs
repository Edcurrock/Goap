using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour
{
    public Text states;
    
    void LateUpdate()
    {
        Dictionary<string,int> worldStates = 
            GWorld.Instance.GetWorld().GetStates();
        states.text = "";
        foreach(var st in worldStates)
        {
            states.text += st.Key + " | " + st.Value + "\n";
        }
    }
}
