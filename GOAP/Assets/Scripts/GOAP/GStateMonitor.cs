using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GStateMonitor : MonoBehaviour
{

    public string state;
    public float stateStrength;
    public float stateDecayRate;
    public WorldStates beliefs;
    public GameObject resPrefab;
    public string queueName;
    public string worldState;
    public GAction action;


    bool stateFound = false;
    float initStrength;

    private void Awake() 
    {
        beliefs = GetComponent<GAgent>().beliefs;
        initStrength = stateStrength;
    }

    void LateUpdate()
    {
        if(action.running)
        {
            stateFound = false;
            stateStrength = initStrength;
        }

        if(!stateFound && beliefs.HasState(state))
        {
            stateFound = true;
        }

        if(stateFound)
        {
            stateStrength -= stateDecayRate * Time.deltaTime;
            if(stateStrength <= 0)
            {
                Vector3 loc = new Vector3(transform.position.x,
                    resPrefab.transform.position.y,transform.transform.position.z);
                GameObject clone = Instantiate(resPrefab,loc,resPrefab.transform.rotation);
                stateFound = false;
                stateStrength = initStrength;
                beliefs.RemoveState(state);
                GWorld.Instance.GetQueue(queueName).AddResource(clone);
                GWorld.Instance.GetWorld().ModifyState(worldState,1);
            }
        }
    }
}
