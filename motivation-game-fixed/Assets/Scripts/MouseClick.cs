using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
public void RaycastDetection()
    {
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        RaycastHit hit;
      
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.name == "Left Foot" || hit.transform.name == "Right Foot")
            {
                hit.transform.localEulerAngles += new Vector3(-15, 0, 0);
            }
            else if(hit.transform.name == "Left Lever" || hit.transform.name == "Right Lever")
            {
                hit.transform.localEulerAngles += new Vector3(12, 0, 0);
            }
            else if (hit.transform.name == "Handle")
            {
                hit.transform.localPosition += new Vector3(0, 0, 0.6f);
            }
            else
            {
                hit.transform.localPosition += new Vector3(0, 0, 0.08f);
            }          
            
        }
    }
}
