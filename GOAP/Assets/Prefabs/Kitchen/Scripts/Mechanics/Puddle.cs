using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puddle : MonoBehaviour
{
    public Garson[] garsons;
    public float puddleSpeedDebuff = 0.24f;
    private bool isQuitting = false;

 
  void OnApplicationQuit()
    {
        isQuitting = true;
    }
    // Start is called before the first frame update
    private void Awake() 
    {
        FindAllGarsons();
    }
    void Start()
    {
        ChangeGarsonSpeed(puddleSpeedDebuff);
    }

    public void ChangeGarsonSpeed(float speed)
    {
        foreach (var item in garsons)
        {
            item.GetComponent<NavMeshAgent>().speed -= speed;
        }
    }
    public void FindAllGarsons()
    {
        garsons = GameObject.FindObjectsOfType<Garson>();
    }

    private void OnDestroy() 
    {
        if(!isQuitting)
        {
            ChangeGarsonSpeed(-puddleSpeedDebuff);
        }
    }
}
