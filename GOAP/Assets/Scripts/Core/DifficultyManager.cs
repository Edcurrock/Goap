using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [Range(0f, 1f)] 
    [SerializeField] float treatChance = 0.5f; 

    public float TreatChance
    {
        get { return treatChance; }
    }
}