using UnityEngine;

public class TestCharacter : GAgent
{
    [SerializeField] Purposes purposesData;
    new void Start()
    {
        
        base.Start();
        if(purposesData)
        {
            foreach (var item in purposesData.purposes)
            {
                goals.Add(item.GetSubGoal(), item.weight);
            }
        }

    }
}