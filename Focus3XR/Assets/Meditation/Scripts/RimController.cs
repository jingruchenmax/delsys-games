using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimController : MonoBehaviour
{
    private RimRenderer[] rimRenderers;
    public float step;
    public Color initialColor;
    [Header("Visual Setting")]
    public float alpha = 0.9f;
    public float range = 12f;
    public float deltaAlpha;
    public float deltaRange;
    void Start()
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

    public void RimRendererInhale()
    {
        alpha += deltaAlpha;
        alpha = Mathf.Clamp(alpha, 0.1f, 0.9f);
        range -= deltaRange;
        range = Mathf.Clamp(range, 1f, 12f);
        foreach (RimRenderer rr in rimRenderers)
        {
            rr.ColorSetAlpha(alpha);
            rr.RimSetRange(range);
        }
    }

    public void RimRendererExhale()
    {
        alpha -= deltaAlpha;
        alpha = Mathf.Clamp(alpha, 0.1f, 0.9f);
        range += deltaRange;
        range = Mathf.Clamp(range, 1f, 12f);
        foreach (RimRenderer rr in rimRenderers)
        {
            rr.ColorSetAlpha(alpha);
            rr.RimSetRange(range);
        }
    }


}
