using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class InteractionRenderer : MonoBehaviour
{
    // this handles two buttons
    private InteractionBehavior interactionBehavior;
    private InteractionType buttonType;
    Material material;
    private bool isToggle=false;
    //onTrigger event is for audio render
    public UnityEvent onTrigger;
    //is the second child

    void Awake()
    {
        interactionBehavior = GetComponent<InteractionBehavior>();
        buttonType = interactionBehavior.interactionProperty.buttonType;
        material = GetComponentInChildren<Renderer>().material;

        Default();
        if (buttonType == InteractionType.Toggle)
        {
            isToggle = false;
        }
    }

    public void Highlight()
    {
        onTrigger.Invoke();
        material.color = Color.yellow;
    }

    //For set back
    public void Default()
    {
        material.color = Color.blue;
        if(isToggle == true)
        {
            material.color = Color.red;
        }
    }

    public void Restart()
    {
        material.color = Color.blue;
        isToggle = false;
    }
    public void UserPressed()
    {
        onTrigger.Invoke();

        if (buttonType == InteractionType.Button)
        {
            material.color = Color.red;
        }


        if (buttonType == InteractionType.Toggle)
        {
            material.color = Color.red;
            isToggle = !isToggle;
        }

    }

    public void UserUnpressed()
    {
        if (buttonType == InteractionType.Button)
        {
            Default();
        }


        if (buttonType == InteractionType.Toggle)
        {
            if (isToggle==false)
            {
                Default();
            }
        }
    }


    public void Hover()
    {
        material.color = new Color(0, 1, 0, 0.1f);
    }


}