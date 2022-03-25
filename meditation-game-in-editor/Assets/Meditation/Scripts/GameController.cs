using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

[ExecuteInEditMode]
public class GameController : MonoBehaviour
{
    [Header("Input")]
    public bool isInhale = false;

    [Header("Guided Meditation")]
    public float breatheIn=6;
    public float breatheHold = 2;
    public float breatheOut=2;
    private float breathPeriod { get { return (breatheIn + breatheOut + breatheHold); } }

    [Header("Feedback")]
    public UnityEvent onInhale;
    public UnityEvent onHold;
    public UnityEvent onExhale;

<<<<<<< HEAD
    [Header("Meditation")]
=======
    [Header("Meditation Guide")]
>>>>>>> cdeceb498722f2645a6806bc702392345004d750
    public UnityEvent onEveryFrame;

    [HideInInspector]
    public float meditationAnimationValue { get { return LerpMeditationValue(); } }

    void Awake()
    {

    }

    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        onEveryFrame.Invoke();
<<<<<<< HEAD
        RespirationInput();
=======

        //in editor simulation
    #if UNITY_EDITOR
        RespirationInput();
    #endif
>>>>>>> cdeceb498722f2645a6806bc702392345004d750
    }


    void RespirationInput()
    {
        if (Input.GetKey(KeyCode.I))
        {
            onInhale.Invoke();
        }
        if (Input.GetKey(KeyCode.H))
        {
            onHold.Invoke();
        }
        if (Input.GetKey(KeyCode.O))
        {
            onExhale.Invoke();
        }
    }

    // meditation guiding

    float LerpMeditationValue()
    {
        float timeInPeriod = Time.timeSinceLevelLoad - Mathf.Floor(Time.timeSinceLevelLoad / breathPeriod)*breathPeriod;
        if (timeInPeriod <= breatheIn)
        {
            return Mathf.Lerp(0, 1, timeInPeriod / breatheIn);
        }

        else if (timeInPeriod > breatheIn && timeInPeriod<=breatheIn+breatheHold)
        {
            return 1;
        }

        else if (timeInPeriod > breatheIn + breatheHold && timeInPeriod<=breathPeriod)
        {
            return Mathf.Lerp(1, 0, (timeInPeriod-(breatheIn+breatheHold)) / breatheOut);      
        }
        return -1;
    }


}
