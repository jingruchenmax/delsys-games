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
            Debug.Log("ray!");
            hit.transform.localPosition -= new Vector3(0, 0, -0.08f);
        }
    }
}
