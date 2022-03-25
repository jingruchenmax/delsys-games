using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereRenderer : MonoBehaviour
{

    float scale = 1;
    Vector3 originalLocalScale;
    Material atmosphereMaterial;
    void Start()
    {
        originalLocalScale = transform.localScale;
        atmosphereMaterial = GetComponent<Renderer>().material;
        InitialSetting();
    }

    void InitialSetting()
    {
        atmosphereMaterial.SetColor("_EmissionColor", new Color(AnimationVariables.initialColor.r, AnimationVariables.initialColor.g, AnimationVariables.initialColor.b));
    }
    public void RainbowColorWave()
    {
        Color rgbColor = atmosphereMaterial.GetColor("_EmissionColor");
        float h;
        float s;
        float v;
        Color.RGBToHSV(rgbColor, out h, out s, out v);
        if (Mathf.Abs(h - 1) < 0.01f) h = 0;
        Color rgbTemp = Color.HSVToRGB(h + AnimationVariables.step, 0.98f, 0.75f);
        float factor = Mathf.Pow(2, -20);
        atmosphereMaterial.SetColor("_EmissionColor", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b) * factor);
    }

    public void SizeScale(float scale)
    {
        transform.localScale = originalLocalScale * (1+(1 - scale)*AnimationVariables.maximumScaleFactor);
    }
}
