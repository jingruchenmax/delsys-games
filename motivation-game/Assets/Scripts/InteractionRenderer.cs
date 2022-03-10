using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace SimonSaysGame
{
    public class InteractionRenderer : MonoBehaviour
    {
        // this handles two buttons
        private InteractionBehavior interactionBehavior;
        private InteractionType buttonType;
        Material material;

        private bool isToggle = false;
        //onTrigger event is for audio render
        public UnityEvent onTrigger;

        private Color initialColor;
        private Color highlightColor;
        private Color pressedColor;
        void Awake()
        {
            interactionBehavior = GetComponent<InteractionBehavior>();
            buttonType = interactionBehavior.interactionProperty.buttonType;
            material = GetComponentInChildren<Renderer>().material;
            SetColors();
            Default();
            if (buttonType == InteractionType.Toggle)
            {
                isToggle = false;
            }
        }

        void SetColors()
        {
            initialColor = material.color;
            float h;
            float s;
            float v;
            Color.RGBToHSV(initialColor, out h, out s, out v);
            Color temp = Color.black;
            highlightColor = temp;
            temp = Color.HSVToRGB(h, Mathf.Clamp(s + 0.5f, 0, 1), Mathf.Clamp(v + 0.5f, 0, 1));
            pressedColor = temp;
        }
        public void Highlight()
        {
            onTrigger.Invoke();

            material.color = highlightColor;
        }

        //For set back
        public void Default()
        {
            material.color = initialColor;
            if (isToggle == true)
            {
                material.color = highlightColor;
            }
        }

        public void Restart()
        {
            material.color = initialColor;
            isToggle = false;
        }
        public void UserPressed()
        {
            onTrigger.Invoke();

            if (buttonType == InteractionType.Button)
            {
                material.color = pressedColor;
            }


            if (buttonType == InteractionType.Toggle)
            {
                material.color = pressedColor;
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
                if (isToggle == false)
                {
                    Default();
                }
            }
        }


    }
}
