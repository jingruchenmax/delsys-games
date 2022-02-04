using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionPositionType
{
    center_arm,
    center_top, 
    left_arm,
    right_arm 
}


public enum InteractionType
{
    Button,
    Toggle,
    Lever
}

public class ButtonProperty
{
    public InteractionPositionType buttonPositionType;
    public InteractionType buttonType;
    public float difficultyLevel;



    public float Difficulty()
    {
        float positionFactor = 1;
        float typeFactor = 1;
        if (buttonPositionType == InteractionPositionType.center_arm)
            positionFactor = 1;
        if (buttonPositionType == InteractionPositionType.center_top)
            positionFactor = 2;
        if (buttonPositionType == InteractionPositionType.left_arm)
            positionFactor = 3;
        if (buttonPositionType == InteractionPositionType.right_arm)
            positionFactor = 3;

        if (buttonType == InteractionType.Button)
            typeFactor = 1;
        if (buttonType == InteractionType.Toggle)
            typeFactor = 1;
        if (buttonType == InteractionType.Lever)
            typeFactor = 3;

        return (positionFactor * typeFactor);
    }
}
