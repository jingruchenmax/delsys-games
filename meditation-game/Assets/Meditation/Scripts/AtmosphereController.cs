using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereController : MonoBehaviour
{
    private AtmosphereRenderer[] atmosphereRenderers;
    private GameController gameController;
    private void Start()
    {
        atmosphereRenderers = GetComponentsInChildren<AtmosphereRenderer>();
        gameController = GameObject.Find("Scripts").GetComponent<GameController>();
    }

    public void AtmosphereRendererUpdate()
    {
        foreach (AtmosphereRenderer ar in atmosphereRenderers)
        {
            ar.RainbowColorWave();
        }
    }


    public void AtmosphereSetSize()
    {
        foreach (AtmosphereRenderer ar in atmosphereRenderers)
        {
            ar.SizeScale(gameController.meditationAnimationValue);         
        }
    }
}
