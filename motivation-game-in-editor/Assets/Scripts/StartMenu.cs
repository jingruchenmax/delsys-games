using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject GameScreen;

    public void StartGame()
    {
        GameScreen.SetActive(true);
        SimonSays.instance.StartGame();
        gameObject.SetActive(false);
    }
}
