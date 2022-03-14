using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceDisplayElement : MonoBehaviour
{
    [SerializeField]private Image display;
    public void SetIcon(Sprite icon)
    {
        display.sprite = icon;
    }
    public void SetColor(Color color)
    {
        display.color = color;
    }
}
