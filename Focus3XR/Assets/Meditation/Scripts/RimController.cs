using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimController : MonoBehaviour
{
    Material planetMaterial;
    // this must be used with celestial shader
    // Start is called before the first frame update
    void Awake()
    {
        planetMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
