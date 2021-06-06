using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Purposes", menuName = "GOAP/Purposes", order = 0)]
public class Purposes : ScriptableObject 
{
    public List<Item> purposes;
}

[Serializable]
public class Item 
{
    public string goalName;
    public int value;
    public bool notRepetitive;
    public int weight;

    public SubGoal GetSubGoal() => new SubGoal(goalName, value, notRepetitive);
    
}