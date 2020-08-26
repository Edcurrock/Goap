using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld {

    // Our GWorld instance
    private static readonly GWorld instance = new GWorld();
    // Our world states
    private static WorldStates world;
    // Queue of patients
    private static Queue<GameObject> patients;
    // Queue of cubicles
    private static Queue<GameObject> cubicles;
    // Queue of offices
    private static Queue<GameObject> offices;
    // Queue of toilets
    private static Queue<GameObject> toilets;

    private static Queue<GameObject> puddles;
    static GWorld() {

        // Create our world
        world = new WorldStates();
        // Create patients array
        patients = new Queue<GameObject>();
        // Create cubicles array
        cubicles = new Queue<GameObject>();
        // Create offices array
        offices = new Queue<GameObject>();
        // Create toilets array
        toilets = new Queue<GameObject>();


        puddles = new Queue<GameObject>();
        // Find all GameObjects that are tagged "Cubicle"
        
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubicle");
        // Then add them to the cubicles Queue

        foreach (GameObject c in cubes) {

            cubicles.Enqueue(c);
        }

        GameObject[] officesGameObjects = GameObject.FindGameObjectsWithTag("Office");
        foreach (GameObject off in officesGameObjects)
        {
            offices.Enqueue(off);
        }

        GameObject[] toiletsGameObjects = GameObject.FindGameObjectsWithTag("Toilet");
        foreach (GameObject toil in toiletsGameObjects)
        {
            toilets.Enqueue(toil);
        }

        // Inform the state
        if (cubes.Length > 0) {
            world.ModifyState("FreeCubicle", cubes.Length);
        }

        // Inform the state
        if (officesGameObjects.Length > 0)
        {
            world.ModifyState("FreeOffice", officesGameObjects.Length);
        }

        if (toiletsGameObjects.Length > 0)
        {
            world.ModifyState("FreeToilet", toiletsGameObjects.Length);
        }

        // Set the time scale in Unity
        Time.timeScale = 5.0f;
    }

    private GWorld() {

    }

    // Add patient
    public void AddPatient(GameObject p) {

        // Add the patient to the patients Queue
        patients.Enqueue(p);
    }

    // Remove patient
    public GameObject RemovePatient() {

        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }

    // Add cubicle
    public void AddCubicle(GameObject p) {

        // Add the patient to the patients Queue
        cubicles.Enqueue(p);
    }

    // Remove cubicle
    public GameObject RemoveCubicle() {

        // Check we have something to remove
        if (cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    }

    // Offices
    public void AddOffice(GameObject off)
    {
        // Add the patient to the patients Queue
        offices.Enqueue(off);
    }

    public GameObject RemoveOffice()
    {

        // Check we have something to remove
        if (offices.Count == 0) return null;
        return offices.Dequeue();
    }

    // Toilets
    public void AddToilet(GameObject toil)
    {
        // Add the patient to the patients Queue
        toilets.Enqueue(toil);
    }

    public GameObject RemoveToilet()
    {
        if (toilets.Count == 0) return null;
        return toilets.Dequeue();
    }

    public void AddPuddle(GameObject pud)
    {
        puddles.Enqueue(pud);
    }

    public GameObject RemovePuddle()
    {
        if (puddles.Count == 0) return null;
        return puddles.Dequeue();
    }

    public static GWorld Instance {

        get { return instance; }
    }

    public WorldStates GetWorld() {

        return world;
    }
}
