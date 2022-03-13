using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimRenderer : MonoBehaviour
{
    public float rimRange = 0.67f;
    Material planetMaterial;
    // currently changed to work with emission color
    // Start is called before the first frame update
    void Start()
    {
        planetMaterial = GetComponent<Renderer>().material;
        InitialSetting();
    }

    void InitialSetting()
    {
        planetMaterial.SetColor("_Color", new Color(AnimationVariables.initialColor.r, AnimationVariables.initialColor.g, AnimationVariables.initialColor.b, 0.9f));
        planetMaterial.SetFloat("_Cutoff", rimRange);
    }
    public void RainbowColorWave()
    {
        Color rgbColor = planetMaterial.GetColor("_Color");
        float h;
        float s;
        float v;
        Color.RGBToHSV(rgbColor, out h, out s, out v);
        if (Mathf.Abs(h - 1) < 0.01f) h = 0;
        Color rgbTemp = Color.HSVToRGB(h + AnimationVariables.step, 0.36f, 0.7f);
        planetMaterial.SetColor("_Color", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b,0.9f));

    }


    public void RimSetRange(float range)
    {
        rimRange = range;
        planetMaterial.SetFloat("_Cutoff", rimRange);
    }
}

