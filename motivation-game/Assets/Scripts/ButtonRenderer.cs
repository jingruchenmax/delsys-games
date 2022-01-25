using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum ButtonType
{
    Button,
    Toggle,
    Knob
}
public class ButtonRenderer : MonoBehaviour
{
    public ButtonType buttonType;
    public int buttonId; // it is set when start the game, and set in SimonSays
    SimonSays ms;
    Material material;
    Material previousMaterial;
    BoxCollider boxCollider;
    private bool isToggle=false;
    public UnityEvent onTrigger;
    //is the second child

    void Awake()
    {
        material = GetComponentInChildren<Renderer>().material;
        ms = GameObject.Find("Scripts").GetComponent<SimonSays>();
        boxCollider = GetComponent<BoxCollider>();
        Default();
        if (buttonType == ButtonType.Toggle)
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

        if (buttonType == ButtonType.Button)
        {
            material.color = Color.red;
        }

        if (buttonType == ButtonType.Knob)
        {
            material.color = Color.red;
            transform.Rotate(new Vector3(0, 0, 30));
        }

        if (buttonType == ButtonType.Toggle)
        {
            material.color = Color.red;
            isToggle = !isToggle;
        }

    }

    public void UserUnpressed()
    {
        if (buttonType == ButtonType.Button)
        {
            Default();
        }

        if (buttonType == ButtonType.Knob)
        {
            Default();
        }

        if (buttonType == ButtonType.Toggle)
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