using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{  
    [Header("Nebula")]
    public GameObject particle;
    Material pMaterial;
    public float inhaleSeconds = 3.0f;
    public float exhaleSeconds = 7.0f;
    float step;

    [Header("Planets")]
    public List<GameObject> planets;
    List<Material> planetMaterials;
    // Start is called before the first frame update

    // the guidance system need to be seperated from here, it is a visual render module

    // rim color rendering system same;
    void Start()
    {
        //Deal with material
        pMaterial = particle.GetComponent<ParticleSystemRenderer>().material;
        Color rgbTemp = Color.HSVToRGB(0, 0.36f, 0.7f);
        pMaterial.SetColor("_TintColor", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b, 0.3f));
        step = 1f / (50f * (inhaleSeconds + exhaleSeconds));

        //Deal with planet
        planetMaterials = new List<Material>();
        foreach (GameObject ob in planets)
        {
            Material m = ob.GetComponent<MeshRenderer>().material;
            planetMaterials.Add(m);
            m.SetColor("_FresnelCol", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b, 0.9f));
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color rgbColor = pMaterial.GetColor("_TintColor");
        float h;
        float s;
        float v;    
        Color.RGBToHSV(rgbColor,out h,out s,out v);
        if (Mathf.Abs(h-1)<0.01f) h = 0;
        Color rgbTemp = Color.HSVToRGB(h+step, 0.36f, 0.7f);
        pMaterial.SetColor("_TintColor", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b, 0.3f));
        foreach (Material m in planetMaterials)
        {
            m.SetColor("_FresnelCol", new Color(rgbTemp.r, rgbTemp.g, rgbTemp.b, 0.9f));
        }
    }
}
