using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaRenderer : MonoBehaviour
{
    public float alphaValue = 0.3f;
    Material nebulaMaterial;
   
    // this must be used with celestial shader
    // Start is called before the first frame update
    void Start()
    {
        nebulaMaterial = GetComponent<Renderer>().material;
        InitialSetting();
    }

    void InitialSetting()
    {
        nebulaMaterial.SetColor("_TintColor", new Color(AnimationVariables.initialColor.r, AnimationVariables.initialColor.g, AnimationVariables.initialColor.b, 0.3f));
    }
    public void RainbowColorWave()
    {
        Color rgbColor = nebulaMaterial.GetColor("_TintColor");
        float h;
        float s;
        float v;
        Color.RGBToHSV(rgbColor, out h, out s, out v);
        if (Mathf.Abs(h - 1) < 0.01f) h = 0;
        Color rgbTemp = Color.HSVToRGB(h + AnimationVariables.step, 0.36f, 0.7f);
        nebulaMaterial.SetColor("_TintColor", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b, alphaValue));
    }

    public void ColorSet(Color color)
    {
        Color setColor = color;
        setColor.a = 0.3f;
        nebulaMaterial.SetColor("_TintColor", setColor);
    }

    public void ColorSetAlpha(float alpha)
    {
        alphaValue = alpha;
    }
}
