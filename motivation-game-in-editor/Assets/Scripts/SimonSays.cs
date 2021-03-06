using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Buttons;


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
        public bool skipTutorial;
        public Zone[] Zones; //Should be in order of and equal to the enum of groups (Buttons.Group)
        public GameObject[] buttons;
        public Text currentRounds;
        public int totalStages = 10;
        public int roundsPerStage = 10;
        public GameObject Failed;
        public GameObject gameUI;
        public GameObject winScreen;
        //public Transform mainUI;

        [Header("Set Pattern")]
        [Tooltip("List Starts at 1, not 0")]
        public CustomGame customGame;
        public List<int> fixedButtonOrder; // Start From 1!!!!

        public SequenceVisualizer sequenceVisualizer;

        //This is the order of button clicks
        //It should always take the button id.
        private List<InteractionBehavior> _buttonOrder = new List<InteractionBehavior>();
        private List<InteractionBehavior> _interactionBehavior = new List<InteractionBehavior>();

        private GameObject finalScreen;
        private int rounds = 0;
        private int stages = 0;

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
        _interactionBehavior = new List<InteractionBehavior>();
        // Add ButtonRenderer to the list
        for (int i = 0; i < buttons.Length; i++)
        {
            InteractionBehavior ib = buttons[i].GetComponentInChildren<InteractionBehavior>();
            ib.buttonId = i;
            _interactionBehavior.Add(ib);
        }

        if (patternMode == InteractionPatternMode.SetPattern)
        {
            totalStages = customGame.Stages.Length;
        }
    }

    void Start()
    {
        //StartGame();
    }

    public void StartGame()
        {
            rounds = 0;
            stage = 0;
            StartNewStage();
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

            InteractionBehavior rndBtn;
            //Button Generating Mode Selection
            if (patternMode == InteractionPatternMode.PureRandom)
            {
                rndBtn = _interactionBehavior[UnityEngine.Random.Range(0, _interactionBehavior.Count)];
                _buttonOrder.Add(rndBtn);
            }
            if (patternMode == InteractionPatternMode.SetPattern)
            {
                rndBtn = _interactionBehavior[fixedButtonOrder[(_buttonOrder.Count) % fixedButtonOrder.Count]];
                _buttonOrder.Add(rndBtn);

            }
            if (patternMode == InteractionPatternMode.WithDifficultyAdjustment)
            {
                // here is the part of threshold on difficulty
                int index = DifficultScalingGenerator();
                rndBtn = _interactionBehavior[index];
                _buttonOrder.Add(rndBtn);

            }
            sequenceVisualizer.AddToFullSequenceDisplay(_buttonOrder[_buttonOrder.Count - 1].icon);
            sequenceVisualizer.UpdateCurrentButtonDisplay(_buttonOrder[counter].icon, counter);
            await Task.Delay(1000);
            ShowOrder();
        }

        private int DifficultScalingGenerator()
        {
            int index = 0;
            return index;
        }

        public void CheckObject(InteractionBehavior ib)
        {
            Debug.Log("Button Check" + ib.buttonId);

        if (ib == _buttonOrder[counter])
            {
                counter++;
                if (counter == _buttonOrder.Count)
                {
                    counter = 0; round++;
                    CheckStageEnd();
                    
                    Debug.Log("Level Up! + Round: " + round);
                }
                else
                {
                    sequenceVisualizer.UpdateCurrentButtonDisplay(_buttonOrder[counter].icon, counter);
                }
            }
            else RestartStage();
        }

        void CheckStageEnd()
        {
            if (round == roundsPerStage && stage == totalStages)
            {
                Debug.Log("Reach the end");
                gameUI.SetActive(false);
                winScreen.SetActive(true);
                sequenceVisualizer.SetTitleText("Restarting...");
                sequenceVisualizer.ClearFullSequenceDisplay();
                // Winning status
            }
            else if (round == roundsPerStage)
            {
                Debug.Log("Stage Level Up! + Stage: " + stage);
                StartNewStage();
            }
            else
            {
                AddObject();
            }
        }

        private async void RestartStage()
        {
            counter = 0;
            round = 0;
            DisableButtons();
            sequenceVisualizer.SetTitleText("You hit the wrong button. Try again");
            for (int i = 0; i < _interactionBehavior.Count; i++)
            {
                await Task.Delay(10);
                _interactionBehavior[i].interactionRenderer.Highlight();
                await Task.Delay(10);
                _interactionBehavior[i].interactionRenderer.Default();
            }
            for (int i = 0; i < _interactionBehavior.Count; i++)
            {
                _interactionBehavior[i].interactionRenderer.Restart();
            }
            await Task.Delay(2000);
            _buttonOrder.Clear();
            sequenceVisualizer.ClearFullSequenceDisplay();
            AddObject();
        }

        private async void StartNewStage()
        {
            stage++;
            counter = 0;
            round = 0;
            if (patternMode == InteractionPatternMode.SetPattern)
            {
                if (customGame.Stages[stage - 1].sequence.isTutorial && skipTutorial)
                {
                    Debug.Log("A tutorial stage was skipped");
                    StartNewStage();
                    return;
                }
                else
                {
                    fixedButtonOrder = customGame.Stages[stage - 1].sequence.GenerateSequence(_interactionBehavior, Zones);
                    roundsPerStage = customGame.Stages[stage - 1].sequence.GetNumberOfRounds();
                }
                    
            }
            DisableButtons();
            await Task.Delay(2000);
            _buttonOrder.Clear();
            sequenceVisualizer.ClearFullSequenceDisplay();
            AddObject();
        }

        private async void ShowOrder()
        {
            DisableButtons();
            sequenceVisualizer.SetTitleText("Showing Patter");
            sequenceVisualizer.setActiveElementToNone();
            for (int i = 0; i < _buttonOrder.Count; i++)
            {
                await Task.Delay(500);
                // show button highlight state
                _buttonOrder[i].interactionRenderer.Highlight();
                sequenceVisualizer.UpdateCurrentButtonDisplay(_buttonOrder[i].icon, i);
                //this is using buttonorder as index again. This will cause difficulty problem
                await Task.Delay(1000);
                // show button default state
                _buttonOrder[i].interactionRenderer.Default();
            }
            sequenceVisualizer.UpdateCurrentButtonDisplay(_buttonOrder[0].icon, 0);
            sequenceVisualizer.SetTitleText("Push the button");
            EnableButtons();
        }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
}


