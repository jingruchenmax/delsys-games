using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class InteractionRenderer : MonoBehaviour
{

    private InteractionBehavior interactionBehavior;
    private InteractionType buttonType;
    Material material;
    private bool isToggle=false;
    //onTrigger event is for audio render
    public UnityEvent onTrigger;
    
    Color highlightColor = Color.yellow;
    Color initialColor = Color.black;
    Color pressedColor = Color.red;
    float intensity = 1;
    float factor;
    void Awake()
    {
        interactionBehavior = GetComponent<InteractionBehavior>();
        buttonType = interactionBehavior.interactionProperty.buttonType;
        material = GetComponentInChildren<Renderer>().material;
        factor =  Mathf.Pow(2, intensity);
        Default();
        if (buttonType == InteractionType.Toggle)
        {
            isToggle = false;
        }
    }

    public void Highlight()
    {
        onTrigger.Invoke();
        material.SetColor("_EmissionColor",new Color(highlightColor.r*factor,highlightColor.g*factor,highlightColor.b*factor));
    }

    //For set back
    public void Default()
    {
        
        material.SetColor("_EmissionColor", initialColor);
        if (isToggle == true)
        {
            material.SetColor("_EmissionColor", new Color(pressedColor.r * factor, pressedColor.g * factor, pressedColor.b * factor));
        }
    }

    public void Restart()
    {
        material.SetColor("_EmissionColor", initialColor);
        isToggle = false;
    }
    public void UserPressed()
    {
        onTrigger.Invoke();
        
        if (buttonType == InteractionType.Button)
        {        
            material.SetColor("_EmissionColor", new Color(pressedColor.r * factor, pressedColor.g * factor, pressedColor.b * factor));
        }


        if (buttonType == InteractionType.Toggle)
        {
            material.SetColor("_EmissionColor", new Color(pressedColor.r * factor, pressedColor.g * factor, pressedColor.b * factor));
            isToggle = !isToggle;
        }

    }

    public void UserUnpressed()
    {
            Default();
    }


}