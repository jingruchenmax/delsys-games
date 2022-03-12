using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Buttons;

[RequireComponent(typeof(InteractionRenderer))]
public class InteractionBehavior : MonoBehaviour
{
    [HideInInspector]
    public InteractionRenderer interactionRenderer;
    public InteractionProperty interactionProperty;
    [Tooltip("Used to locate buttons based on group and the visual")]
    public ButtonInfo buttonIdentification;
    public Sprite icon;
    [Header("Used Internally. Dont change this")]
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
