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
        range = 0.67f;
        deltaRange = (AnimationVariables.speed / 10f);
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
        Debug.Log("inhale");
        range = Mathf.Clamp(range, 0.29f, 0.67f);
        foreach (RimRenderer rr in rimRenderers)
        {
            rr.RimSetRange(range);

        }
    }

    public void RimRendererExhale()
    {
        range += deltaRange;
        Debug.Log("exhale");
        range = Mathf.Clamp(range, 0.29f, 0.67f);
        foreach (RimRenderer rr in rimRenderers)
        {
            rr.RimSetRange(range);
        }
    }


}
