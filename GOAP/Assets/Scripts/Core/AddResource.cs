using UnityEngine;
using System;
using UnityEngine.UI;

public enum ResourcesState
{
    Toilet,
    Cubicle
}

public class AddResource : MonoBehaviour 
{

    [SerializeField]
    public ResourcesState state = ResourcesState.Cubicle; 
    
    [SerializeField]
    Text stateText = null;

    private void Start() 
    {
        stateText.text = state.ToString();
    }

    public void OnChangeRes()
    {
        stateText.text = "";
        state +=1;
        if((int) state == Enum.GetNames(typeof(ResourcesState)).Length)
        {
            state = 0;
        }
        stateText.text = state.ToString();
    }

}