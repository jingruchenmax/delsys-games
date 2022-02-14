using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimController : MonoBehaviour
{
    private RimRenderer[] rimRenderers;
    public float step;
    public Color initialColor;
    private void Start()
    {
        rimRenderers = GetComponentsInChildren<RimRenderer>();
        foreach(RimRenderer rr in rimRenderers)
        {
            rr.step = step;
            rr.initialColor = initialColor;
        }
    }

    public void RimRendererUpdate()
    {
        foreach(RimRenderer rr in rimRenderers)
        {
            rr.RainbowColorWave();
        }
    }
}
