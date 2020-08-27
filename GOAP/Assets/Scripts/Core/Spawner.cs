using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    int spawnCount = 5;

    [SerializeField]
    GameObject patientPrefab = null;

    [SerializeField]
    Transform spawnPos = null;

    int currentCount = 0;

    public int timeToSpawn = 1;
    public int spawnRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instant",timeToSpawn,spawnRate);
    }

    private void Instant()
    {
        if (currentCount < spawnCount)
        {
            currentCount ++;
            Instantiate(patientPrefab, spawnPos.position, Quaternion.identity);
        }
        else
        {
            CancelInvoke("Instant");
        }
    }
}
