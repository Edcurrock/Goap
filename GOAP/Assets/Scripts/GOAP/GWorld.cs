using System.Collections.Generic;
using UnityEngine;


public class ResourceQueue
{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string tag, string modState, WorldStates wStates)
    {
        this.tag = tag;
        this.modState = modState;
        if(tag != "")
        {
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach(var res in resources)
            {
                que.Enqueue(res);
            }
        }

        if(modState != "")
        {
            wStates.ModifyState(modState, que.Count);
        }
    }

    public void AddResource(GameObject res)
    {
        que.Enqueue(res);
    }

    public GameObject RemoveResource()
    {
        if(que.Count == 0)
        {
            return null;
        }
        return que.Dequeue();
    }
}

public sealed class GWorld {

    // Our GWorld instance
    private static readonly GWorld instance = new GWorld();
    // Our world states
    private static WorldStates world;
    // Queue of patients
    private static ResourceQueue patients;
    // Queue of cubicles
    private static ResourceQueue cubicles;
    // Queue of offices
    private static ResourceQueue offices;
    // Queue of toilets
    private static ResourceQueue toilets;

    private static ResourceQueue puddles;

    private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();

    static GWorld() 
    {
        // Create our world
        world = new WorldStates();
        patients = new ResourceQueue("","",world); 
        resources.Add("patients",patients);
        cubicles = new ResourceQueue("Cubicle", "FreeCubicle", world);
        resources.Add("cubicles", cubicles);
        offices = new ResourceQueue("Office", "FreeOffice", world);
        resources.Add("offices", offices);
        toilets = new ResourceQueue("Toilet", "FreeToilet", world);
        resources.Add("toilets", toilets);
        puddles = new ResourceQueue("Puddle", "Puddles", world);
        resources.Add("puddles", puddles);
        
        // Set the time scale in Unity
        Time.timeScale = 5.0f;
    }

    public ResourceQueue GetQueue(string type)
    {
        return resources[type];
    }
    private GWorld() 
    {

    }

    public static GWorld Instance {

        get { return instance; }
    }

    public WorldStates GetWorld() {

        return world;
    }
}
