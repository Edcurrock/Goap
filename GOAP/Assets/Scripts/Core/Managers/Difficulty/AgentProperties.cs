using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentProperties : MonoBehaviour
{
    List<GAgent> agents;
    [SerializeField] GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateProp",2f);
    }

    private void CreateProp()
    {
        int i = 1;
        foreach (var item in GameObject.FindObjectsOfType<GAgent>())
        {
            int j = 10;
            Debug.Log(item.actions[0]);
            foreach (var act in item.actions)
            {
                
                var child = GameObject.Instantiate(prefab, new Vector3(transform.position.x, transform.position.y - 40 * i + j, transform.position.z),
                    Quaternion.identity);
                child.transform.parent = transform;
                child.transform.GetChild(0).GetComponent<Text>().text = act.actionName;
                j-=40;

            }
            i++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
