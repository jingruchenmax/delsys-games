using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimController : MonoBehaviour
{
    private RimRenderer[] rimRenderers;
    [HideInInspector]
    public float range;
    [HideInInspector]
    public float deltaRange;
    void Start()
    {
        rimRenderers = GetComponentsInChildren<RimRenderer>();
        range = 12f;
        deltaRange = AnimationVariables.speed;
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
        range -= deltaRange;
        range = Mathf.Clamp(range, 1f, 12f);
        foreach (RimRenderer rr in rimRenderers)
        {
            rr.RimSetRange(range);

        }
    }

    public void RimRendererExhale()
    {
        range += deltaRange;
        range = Mathf.Clamp(range, 1f, 12f);
        foreach (RimRenderer rr in rimRenderers)
        {
            rr.RimSetRange(range);
        }
    }


}
