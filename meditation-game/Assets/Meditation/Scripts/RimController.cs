using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimController : MonoBehaviour
{
    private RimRenderer[] rimRenderers;

    private void Start()
    {
        rimRenderers = GetComponentsInChildren<RimRenderer>();
    }
}
