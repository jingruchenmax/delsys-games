using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(InteractionRenderer))]
public class InteractionBehavior : MonoBehaviour, IComparable<InteractionBehavior>
{
    [HideInInspector]
    public InteractionRenderer interactionRenderer;
    public InteractionProperty interactionProperty;
    public int buttonId; // it is set when start the game, and set in SimonSays
    private int difficultyLevel;
    SimonSays ms;
    BoxCollider boxCollider;
    public UnityEvent onPressed, onReleased;

    void Awake()
    {
        interactionRenderer = GetComponent<InteractionRenderer>();
        ms = GameObject.Find("Scripts").GetComponent<SimonSays>();
        boxCollider = GetComponent<BoxCollider>();
        difficultyLevel = interactionProperty.difficultyLevel;
        print(difficultyLevel);
        onPressed.AddListener(btn);
        onPressed.AddListener(interactionRenderer.UserPressed);
        onReleased.AddListener(interactionRenderer.UserUnpressed);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public int CompareTo(InteractionBehavior compareProperty)
    {
        Debug.Log("used");
        // A null value means that this object is greater.
        if (compareProperty == null)
            return 1;

        else
        {
            Debug.Log("changed");
            return this.difficultyLevel.CompareTo(compareProperty.difficultyLevel);
        }

    }

    //public override int GetHashCode()
    //{
    //    return ;
    //}
    public bool Equals(InteractionProperty other)
    {
        if (other == null) return false;
        else 
        {
            Debug.Log("equal");
            return (this.difficultyLevel.Equals(other.difficultyLevel));
        } 
    }

}
