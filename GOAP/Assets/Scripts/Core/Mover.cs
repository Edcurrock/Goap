using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Mover : MonoBehaviour
{
    bool isMovable = false;
    GameObject target = null;

    [SerializeField]
    Text text;

    [SerializeField]
    AddResource stateRes = null;

    [SerializeField]
    NavMeshSurface surface;

    string targetTag = "";
  
    void Update()
    {
        targetTag = stateRes.state.ToString();
        if(Input.GetMouseButtonDown(0) && !isMovable)
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if(hasHit && hit.collider.tag == targetTag)
            {
                isMovable = true;
                target = hit.collider.gameObject;
                if(GWorld.Instance.GetQueue("toilets").que.Contains(target) && target.tag == "Toilet")
                {
                    GWorld.Instance.GetQueue("toilets").RemoveForDragging(target);
                    GWorld.Instance.GetWorld().ModifyState("FreeToilet", -1);
                }
            }
        }
        else if(Input.GetMouseButtonDown(0) && isMovable)
        {
            isMovable = false;
            if(!GWorld.Instance.GetQueue("toilets").que.Contains(target) && target.tag == "Toilet")
            {
                GWorld.Instance.GetQueue("toilets").AddResource(target);
                GWorld.Instance.GetWorld().ModifyState("FreeToilet", 1);

            }
            surface.BuildNavMesh();
            target = null;
        }
        if(isMovable)
        {
            RaycastHit hit;
            Physics.Raycast(GetMouseRay(),out hit, Mathf.Infinity, 1 << 8);
            target.transform.position = hit.point;
            if(Input.GetMouseButtonDown(1))
            {
                target.transform.RotateAround(target.transform.position,Vector3.down,90);
            }
        }
        
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    
}
