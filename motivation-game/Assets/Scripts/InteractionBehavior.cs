using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(InteractionRenderer))]
public class InteractionBehavior : MonoBehaviour
{
    [HideInInspector]
    public InteractionRenderer interactionRenderer;
    public InteractionProperty interactionProperty;
    public int buttonId; // it is set when start the game, and set in SimonSays

    SimonSays simonSays;
    BoxCollider boxCollider;
    public UnityEvent onPressed, onReleased;

    void Awake()
    {
        interactionRenderer = GetComponent<InteractionRenderer>();
        simonSays = GameObject.Find("Scripts").GetComponent<SimonSays>();
        boxCollider = GetComponent<BoxCollider>();     
        onPressed.AddListener(CheckObject);
        onPressed.AddListener(interactionRenderer.UserPressed);
        onReleased.AddListener(interactionRenderer.UserUnpressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckObject()

    {
        simonSays.CheckObject(this);
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
