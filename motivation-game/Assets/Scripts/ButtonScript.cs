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

    //is the second child

    void Awake()
    {
        material = GetComponentInChildren<Renderer>().material;
        ms = GameObject.Find("Scripts").GetComponent<SimonSays>();
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

}