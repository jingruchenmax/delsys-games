using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaController : MonoBehaviour
{
    private NebulaRenderer[] nebulaRenderers;
    private GameController gameController;
    private void Start()
    {
        nebulaRenderers = GetComponentsInChildren<NebulaRenderer>();
        gameController = GameObject.Find("Scripts").GetComponent<GameController>();
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

    public void NebulaRendererSetColorAlpha()
    {
        foreach (NebulaRenderer nr in nebulaRenderers)
        {
            nr.ColorSetAlpha(gameController.meditationAnimationValue);
        }
    }

}
