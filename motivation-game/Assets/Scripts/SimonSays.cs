using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SimonSays : MonoBehaviour
{
    public static SimonSays instance { get; private set; }

    public GameObject[] buttons;
    public Text currentRounds;
    public GameObject Failed;
    //public Transform mainUI;
    //This is the order of button clicks
    private List<GameObject> _buttonOrder = new List<GameObject>();
    private List<ButtonScript> _buttonScripts= new List<ButtonScript>();  
    private GameObject finalScreen;
    private int rounds = 1;

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


    System.Random rnd = new System.Random();

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

        // Add ButtonScript to the list
        for (int i = 0; i < buttons.Length; i++)
        {
            _buttonScripts.Add(buttons[i].GetComponentInChildren<ButtonScript>());
        }

        AddObject();
    }

    // Disable and enable buttons can be changed into one toggle function, but here separated for clearity?
    private void DisableButtons()
    {
        for (int i = 0; i < _buttonScripts.Count; i++)
        {
            _buttonScripts[i].enabled = false;
        }
    }

    private void EnableButtons()
    {
        for (int i = 0; i < _buttonScripts.Count; i++)
        {
            _buttonScripts[i].enabled = true;
        }
    }

    void AddObject()
    {
        // get one random button from button list, and add into order list (Index only, start from 0)
        DisableButtons();
        GameObject rndBtn = buttons[rnd.Next(buttons.Length)];
        _buttonOrder.Add(rndBtn);
        Debug.Log(_buttonOrder.Count);
        ShowOrder();
    }

    public void CheckObject(GameObject obj)
    {
        //check end state, if true, continue adding object
        if (obj == _buttonOrder[counter])
        {
            Debug.Log("correct");
            if (counter == (_buttonOrder.Count - 1))
            {
                counter = 0; round++; AddObject(); 
            }
            else 
            { 
                counter++;
            }
        }

        else Restart();
    }

    private async void Restart()
    {
        Debug.Log("Game Restart");
        counter = 0;
        round = 1;
        _buttonOrder.Clear();
        DisableButtons();
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
            _buttonScripts[i].Highlight();
            await Task.Delay(1000);
            // show button default state
            _buttonScripts[i].Default();
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