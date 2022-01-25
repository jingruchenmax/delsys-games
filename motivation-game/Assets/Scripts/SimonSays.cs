using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public enum ButtonPatternMode
{
    PureRandom,
    SetPattern,
    WithDifficultyAdjustment
}
//deal with multiply button types


public class SimonSays : MonoBehaviour
{
    public static SimonSays instance { get; private set; }
    public ButtonPatternMode patternMode;
    [Header("Core")]
    public GameObject[] buttons;
    public Text currentRounds;
    public GameObject Failed;
    //public Transform mainUI;

    [Header("Set Pattern")]
    [Tooltip("List Starts at 1, not 0")]
    public List<int> setButtonOrder; // Start From 1!!!!

    //This is the order of button clicks
    private List<int> _buttonOrder = new List<int>();
    private List<ButtonRenderer> _buttonRenderers = new List<ButtonRenderer>();
    private GameObject finalScreen;
    private int rounds = 1;

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

        // Add ButtonRenderer to the list
        for (int i = 0; i < buttons.Length; i++)
        {
            ButtonRenderer bs = buttons[i].GetComponentInChildren<ButtonRenderer>();
            bs.buttonId = i;
            _buttonRenderers.Add(bs);

        }

        AddObject();
    }

    // Disable and enable buttons can be changed into one toggle function, but here separated for clearity?
    private void DisableButtons()
    {
        for (int i = 0; i < _buttonRenderers.Count; i++)
        {
            _buttonRenderers[i].DisablePhysicalTouch();
        }
    }

    private void EnableButtons()
    {
        for (int i = 0; i < _buttonRenderers.Count; i++)
        {
            _buttonRenderers[i].EnablePhysicalTouch();
        }
    }

    async void AddObject()
    {
        // get one random button from button list, and add into order list (Index only, start from 0)
        DisableButtons();
        await Task.Delay(2000);

        int rndBtn = 0;
        //Button Generating Mode Selection
        if (patternMode == ButtonPatternMode.PureRandom)
        {
            rndBtn = UnityEngine.Random.Range(0, _buttonRenderers.Count);
        }
        if (patternMode == ButtonPatternMode.SetPattern)
        {
            rndBtn = setButtonOrder[(_buttonOrder.Count) % setButtonOrder.Count] - 1;
            Debug.Log(rndBtn);
        }
        if (patternMode == ButtonPatternMode.WithDifficultyAdjustment)
        {
            rndBtn = setButtonOrder[(_buttonOrder.Count) % setButtonOrder.Count] - 1;
            Debug.Log(rndBtn);
        }

        _buttonOrder.Add(rndBtn);
        ShowOrder();
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
        for (int i = 0; i < _buttonRenderers.Count; i++)
        {
            await Task.Delay(10);
            _buttonRenderers[i].Highlight();
            _buttonRenderers[i].Default();
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
            _buttonRenderers[_buttonOrder[i]].Highlight();
            await Task.Delay(1000);
            // show button default state
            _buttonRenderers[_buttonOrder[i]].Default();
        }
        EnableButtons();
    }


    private void FinalScreen()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        //  finalScreen = Instantiate(Failed, pos, Quaternion.identity);
        //   finalScreen.SetActive(false);
        //  finalScreen.transform.SetParent(mainUI, false);
    }
}
