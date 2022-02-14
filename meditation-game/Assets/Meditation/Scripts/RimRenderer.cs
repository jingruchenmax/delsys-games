using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimRenderer : MonoBehaviour
{
    public Color initialColor = Color.HSVToRGB(0, 0.36f, 0.7f);
    public float step = 0.01f; //color changing speed
    public float alphaValue = 0.9f;
    public float rimRange = 12f;
    Material planetMaterial;
    // this must be used with celestial shader
    // Start is called before the first frame update
    void Start()
    {
        planetMaterial = GetComponent<Renderer>().material;
        InitialSetting();
    }

    void InitialSetting()
    {
        planetMaterial.SetColor("_FresnelCol", new Color(initialColor.r, initialColor.g, initialColor.b, 0.9f));
    }
    public void RainbowColorWave()
    {
        Color rgbColor = planetMaterial.GetColor("_FresnelCol");
        float h;
        float s;
        float v;
        Color.RGBToHSV(rgbColor, out h, out s, out v);
        if (Mathf.Abs(h - 1) < 0.01f) h = 0;
        Color rgbTemp = Color.HSVToRGB(h + step, 0.36f, 0.7f);
        planetMaterial.SetColor("_FresnelCol", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b, alphaValue));
        planetMaterial.SetFloat("_FresnelPow", rimRange);

    }

    public void ColorSetAlpha(float alpha)
    {
        alphaValue = alpha;
    }

    public void RimSetRange(float range)
    {
        rimRange = range;
    }
}

