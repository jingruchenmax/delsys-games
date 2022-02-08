using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

[Serializable]
public class InteractionProperty
{
    public InteractionPositionType buttonPositionType;
    public InteractionType buttonType;

}
