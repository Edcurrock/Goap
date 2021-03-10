using UnityEngine;

public class CameraMover : MonoBehaviour 
{
    [SerializeField]
    GameObject anchorRotate = null;

    [SerializeField]
    TimeScale timeScale = null;


    private void LateUpdate()
    {
        if(Input.GetKey("d"))
        {
            transform.RotateAround(anchorRotate.transform.position, Vector3.down,
                (40 / timeScale.GetTimeScale()) * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {
            transform.RotateAround(anchorRotate.transform.position, Vector3.up, 
                (40  / timeScale.GetTimeScale()) * Time.deltaTime);
        }

        else if (Input.GetKey("w"))
        {
            transform.RotateAround(anchorRotate.transform.position, Vector3.left,
                (40 / timeScale.GetTimeScale()) * Time.deltaTime);
        }

        else if (Input.GetKey("s"))
        {
            transform.RotateAround(anchorRotate.transform.position, Vector3.right,
                (40 / timeScale.GetTimeScale()) * Time.deltaTime);
        }
    }
}