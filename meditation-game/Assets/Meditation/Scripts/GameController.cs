using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    [Header("Guided Meditation")]
    public float breathIn=6;
    public float breathOut=2;
    public float animationSmoothness = 0.2f;

    //Out animation will be divided into two parts, one in the beginning and one in the end.
    public AnimationCurve curve;

    [Header("Controllers")]
    public NebulaController nebulaController;
    public RimController rimController;
    public float step = 0.001f;

    void Awake()
    {
        nebulaController.step = step;
        rimController.step = step;
        nebulaController.initialColor = Color.HSVToRGB(0, 0.36f, 0.7f);
        rimController.initialColor = Color.HSVToRGB(0, 0.36f, 0.7f);
        curve = AnimationCurve.Constant(0, 8, 0.3f);
    }

    private void Start()
    {
        InitiateMeditationGuide();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rimController.RimRendererUpdate();
        nebulaController.NebulaRendererUpdate();
        MeditationGuide();
    }

    // This is for guiding

    void InitiateMeditationGuide()
    {
        curve = AnimationCurve.Constant(0, breathIn+breathOut, 0.3f);
        curve.AddKey(breathOut/2- animationSmoothness, 0.3f);
        curve.AddKey(breathOut/2,0.5f);
        curve.AddKey(breathOut / 2 + animationSmoothness, 0.3f);

        curve.AddKey((breathOut / 2 + breathIn)- animationSmoothness, 0.3f);
        curve.AddKey((breathOut / 2 + breathIn), 0.5f);
        curve.AddKey((breathOut / 2 + breathIn)+ animationSmoothness, 0.3f);

        curve.postWrapMode = WrapMode.Loop;

        for(int i = 0; i < curve.keys.Length; i++)
        {
            AnimationUtility.SetKeyLeftTangentMode(curve, i, AnimationUtility.TangentMode.ClampedAuto);
        }
    }
    void MeditationGuide()
    {
        nebulaController.NebulaRendererSetColorAlpha(curve.Evaluate(Time.realtimeSinceStartup));
    }
}
