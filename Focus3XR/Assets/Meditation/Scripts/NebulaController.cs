using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaController : MonoBehaviour
{
    private NebulaRenderer[] nebulaRenderers;
    public Color initialColor;
    public float step;
    private void Start()
    {
        nebulaRenderers = GetComponentsInChildren<NebulaRenderer>();
        foreach (NebulaRenderer nr in nebulaRenderers)
        {
            nr.step = step;
            nr.initialColor = initialColor;
        }
    }

    public void NebulaRendererUpdate()
    {
        foreach (NebulaRenderer nr in nebulaRenderers)
        {
            nr.RainbowColorWave();
        }
    }

    public void NebulaRendererSetColor(Color color)
    {
        foreach (NebulaRenderer nr in nebulaRenderers)
        {
            nr.ColorSet(color);
        }
    }

    public void NebulaRendererSetColorAlpha(float alpha)
    {
        foreach (NebulaRenderer nr in nebulaRenderers)
        {
            nr.ColorSetAlpha(alpha);
        }
    }

}
