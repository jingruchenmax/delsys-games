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
    private int activeElement;
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
        sequenceElements.Add(newElement.GetComponent<SequenceDisplayElement>());
    }
    public void ClearFullSequenceDisplay()
    {
        for (int i = 0; i < sequenceElements.Count; i++)
        {
            Destroy(sequenceElements[i].gameObject);
        }
        sequenceElements.Clear();
    }
    public void SetActiveSequenceDisplayElement(int element)
    {
        sequenceElements[element].SetColor(selected);
        sequenceElements[activeElement].SetColor(notSelected);
        activeElement = element;
    }
}
