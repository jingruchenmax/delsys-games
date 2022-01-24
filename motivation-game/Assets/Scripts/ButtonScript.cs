using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ButtonScript : MonoBehaviour
{
    
    public int buttonId; // it is set when start the game, and set in SimonSays
    SimonSays ms;
    Material material;
    BoxCollider boxCollider;
    //is the second child

    void Awake()
    {
        material = GetComponentInChildren<Renderer>().material;
        ms = GameObject.Find("Scripts").GetComponent<SimonSays>();
        boxCollider = GetComponent<BoxCollider>();
        Default();
    }

    public void Highlight()
    {
        material.color = Color.yellow;
    }

    public void Default()
    {
        material.color = Color.blue;
    }

    public void Hover()
    {
        material.color = Color.green;
    }
    public void btn()
    {
        ms.CheckObject(buttonId);
    }

    public void DisablePhysicalTouch()
    {
        boxCollider.enabled = false;
    }

    public void EnablePhysicalTouch()
    {
        boxCollider.enabled = true;
    }
}