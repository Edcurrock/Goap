using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRepeat : MonoBehaviour
{
    [SerializeField] 
    int spawnCount = 5;

    [SerializeField]
    GameObject patientPrefab = null;

    [SerializeField]
    Transform spawnPos = null;

    [SerializeField]
    float timeToSpawnAgain = 15f;
    float timer = 0f;

    int currentCount = 0;

    public int timeToSpawn = 1;
    public int spawnRate = 2;

    float timerToSpawn = 0;

    private void Update() 
    {

        timerToSpawn += Time.deltaTime;
        if(currentCount < spawnCount)
        {
            timerToSpawn += Time.deltaTime;
            if(timerToSpawn - timeToSpawn >= 0)
            {
                Instantiate(patientPrefab, spawnPos.position, Quaternion.identity);
                timerToSpawn = 0;
                currentCount ++;
            }
            
        }
        else
        {
            timer += Time.deltaTime;
            if(timer - timeToSpawnAgain >= 0)
            {
                currentCount = 0;
                timer = 0;
            }
        }
    }

    private void Instant()
    {
        if (currentCount < spawnCount)
        {
            currentCount ++;
            Instantiate(patientPrefab, spawnPos.position, Quaternion.identity);
        }
        
    }
}
