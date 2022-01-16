using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ButtonScript : MonoBehaviour
{
    public UnityEvent interactEvent;
    public bool canBeHit;
    SimonSays ms;
    Material material;
    //is the second child

    void Awake()
    {
        material = GetComponent<Renderer>().material;
        ms = GameObject.Find("Scripts").GetComponent<SimonSays>();
        canBeHit = false;
        Default();
    }

    public void Highlight()
    {
        material.color = Color.yellow;
        canBeHit = false;
    }

    public void Default()
    {
        material.color = Color.blue;
        canBeHit = true;
    }

    public void CanHit()
    {
        material.color = Color.gray;
    }
    public void btn()
    {
        if (canBeHit)
        {
            ms.CheckObject(gameObject);
            canBeHit = false;
        }
    }

}