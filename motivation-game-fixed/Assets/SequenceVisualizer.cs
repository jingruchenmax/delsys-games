using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequenceVisualizer : MonoBehaviour
{
    [SerializeField] private Image currentButtonDisplay;
    [SerializeField] private GameObject fullSequenceDisplay;
    [SerializeField] private GameObject sequenceElementDisplay;
    [SerializeField]private List<SequenceDisplayElement> sequenceElements;
    private int activeElement = -1;
    private Color selected = new Color(1, 1, 1, 1f);
    private Color notSelected = new Color(1, 1, 1, 0.2f);

    public void UpdateCurrentButtonDisplay(Sprite icon, int listPosition)
    {
        currentButtonDisplay.sprite = icon;
        SetActiveSequenceDisplayElement(listPosition);
    }
    public void AddToFullSequenceDisplay(Sprite icon)
    {
        GameObject newElement = Instantiate(sequenceElementDisplay, fullSequenceDisplay.transform);
        newElement.GetComponent<SequenceDisplayElement>().SetIcon(icon);
        newElement.GetComponent<SequenceDisplayElement>().SetColor(notSelected);
        sequenceElements.Add(newElement.GetComponent<SequenceDisplayElement>());
    }
    public void setActiveElementToNone()
    {
        activeElement = -1;
    }
    public void ClearFullSequenceDisplay()
    {
        for (int i = 0; i < sequenceElements.Count; i++)
        {
            Destroy(sequenceElements[i].gameObject);
        }
        sequenceElements.Clear();
        activeElement = -1;
    }
    public void SetActiveSequenceDisplayElement(int element)
    {
        sequenceElements[element].SetColor(selected);
        if(activeElement >= 0)
        {
            sequenceElements[activeElement].SetColor(notSelected);
        }
        activeElement = element;
    }
}
