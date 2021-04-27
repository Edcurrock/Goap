using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty Data", menuName = "Difficulty Data")]
public class DifficultyData : ScriptableObject
{
    ////Garsons////
    public float restChance = 0.5f;
    public float speedDebuff = 1f;


    [Range(0f, 1f)]
    public float puddlesChance = 0.25f;


    ////Game////
    public int winScore = 8;

}
