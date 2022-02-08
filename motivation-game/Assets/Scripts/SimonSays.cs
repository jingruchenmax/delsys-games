using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public enum InteractionPatternMode
{
    PureRandom,
    SetPattern,
    WithDifficultyAdjustment
}
//deal with multiply button types


public class SimonSays : MonoBehaviour
{
    public static SimonSays instance { get; private set; }
    public InteractionPatternMode patternMode;
   
    [Header("Core")]
    public GameObject[] buttons;
    public Text currentRounds;
    public int currentStage; //Stage will be the "real" levl
    public int totalStages = 10;
    public int numberPerStage = 10;
    public GameObject Failed;
    //public Transform mainUI;

    [Header("Set Pattern")]
    [Tooltip("List Starts at 1, not 0")]
    public List<int> setButtonOrder; // Start From 1!!!!

    //This is the order of button clicks
    private List<int> _buttonOrder = new List<int>();
   // private List<InteractionRenderer> _buttonRenderers = new List<InteractionRenderer>();
    private List<InteractionBehavior> _interactionBehavior = new List<InteractionBehavior>();
    // All interaction should be accessed from behavior not renderer.
    private GameObject finalScreen;
    private int rounds = 1;
    private int stages = 1;

    //Set level of difficulty

    private int round
    {
        get { return rounds; }
        set
        {
            rounds = value;
            currentRounds.text = "Round: " + rounds;
        }
    }

    private int stage
    {
        get { return stages; }
        set
        {
            stages = value;
            currentRounds.text += "Stage: " + rounds;
        }
    }
    // count replay index
    private int counter = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FinalScreen();
        _interactionBehavior = new List<InteractionBehavior>();
        // Add ButtonRenderer to the list
        for (int i = 0; i < buttons.Length; i++)
        {
            InteractionBehavior ib = buttons[i].GetComponentInChildren<InteractionBehavior>();
            ib.buttonId = i;
            Debug.Log("Button: " + i + " Difficulty: " + ib.interactionProperty.difficultyLevel);
            _interactionBehavior.Add(ib);
        }
        
        _interactionBehavior.Sort();

        //for testing the sort method
        //for (int i = 0; i < buttons.Length; i++)
        //{
        //    Debug.Log("Button: " + _interactionBehavior[i].GetComponentInChildren<InteractionBehavior>().buttonId);
        //}
        AddObject();

        
    }

    // Disable and enable buttons can be changed into one toggle function, but here separated for clearity?
    private void DisableButtons()
    {
        for (int i = 0; i < _interactionBehavior.Count; i++)
        {
            _interactionBehavior[i].DisablePhysicalTouch();
        }
    }

    private void EnableButtons()
    {
        for (int i = 0; i < _interactionBehavior.Count; i++)
        {
            _interactionBehavior[i].EnablePhysicalTouch();
        }
    }

    async void AddObject()
    {
        // get one random button from button list, and add into order list (Index only, start from 0)
        DisableButtons();
        await Task.Delay(2000);

        int rndBtn = 0;
        //Button Generating Mode Selection
        if (patternMode == InteractionPatternMode.PureRandom)
        {
            rndBtn = UnityEngine.Random.Range(0, _interactionBehavior.Count);
        }
        if (patternMode == InteractionPatternMode.SetPattern)
        {
            rndBtn = setButtonOrder[(_buttonOrder.Count) % setButtonOrder.Count] - 1;
            Debug.Log(rndBtn);
        }
        if (patternMode == InteractionPatternMode.WithDifficultyAdjustment)
        {
            // here is the part of threshold on difficulty

            rndBtn = DifficultScalingGenerator();

            Debug.Log(rndBtn);
        }

        _buttonOrder.Add(rndBtn);
        ShowOrder();
    }

    private int DifficultScalingGenerator()
    {
        int index = 0;


        return index;
    }

    public void CheckObject(int id)
    {
        //check end state, if true, continue adding object
        if (id == _buttonOrder[counter])
        {
            if (counter < (_buttonOrder.Count - 1))
            {
                counter++;
            }
            else
            {
                counter = 0; round++; AddObject();
                Debug.Log("Level Up! + Round: " + "round");
            }
        }

        else Restart();
    }

    private async void Restart()
    {
        counter = 0;
        round = 1;
        _buttonOrder.Clear();
        Debug.Log("Game Restart " + _buttonOrder.Count);
        DisableButtons();
        for (int i = 0; i < _interactionBehavior.Count; i++)
        {
            await Task.Delay(10);
            _interactionBehavior[i].interactionRenderer.Highlight();
            await Task.Delay(100);
            _interactionBehavior[i].interactionRenderer.Default();
        }
        // finalScreen.SetActive(true);
        await Task.Delay(2000);
        AddObject();
        //   finalScreen.SetActive(false);
    }

    private async void ShowOrder()
    {
        for (int i = 0; i < _buttonOrder.Count; i++)
        {

            await Task.Delay(500);
            // show button highlight state
            _interactionBehavior[_buttonOrder[i]].interactionRenderer.Highlight();
            await Task.Delay(1000);
            // show button default state
            _interactionBehavior[_buttonOrder[i]].interactionRenderer.Default();
        }
        EnableButtons();
    }


    private void FinalScreen()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        //  finalScreen = Instantiate(Failed, pos, Quaternion.identity);
        //  finalScreen.SetActive(false);
        //  finalScreen.transform.SetParent(mainUI, false);

    }
}
