using UnityEngine;
using UnityEngine.UI;

public class TimeScale : MonoBehaviour
{
    [SerializeField]
    int[] timeScaleVar = new int[3]{1,5,10};

    int index = 0;
    [SerializeField]
    Text textField = null;

    private void Start() 
    {
        textField.text = timeScaleVar[0].ToString() + " sec";
        Time.timeScale = timeScaleVar[index];
    }

    public void OnTimeScaleChange()
    {
        // textField.text = "";
        index ++;
        if(index == timeScaleVar.Length)
            index = 0;
        textField.text = timeScaleVar[index].ToString() + " sec";
        Time.timeScale = timeScaleVar[index];
    }

    public int GetTimeScale()
    {
        return timeScaleVar[index];
    }
}