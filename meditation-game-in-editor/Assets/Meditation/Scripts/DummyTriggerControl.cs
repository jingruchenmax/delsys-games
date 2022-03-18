using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTriggerControl : MonoBehaviour
{
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(0))
        {
            gameController.onInhale.Invoke();
        }
        else 
        {
            gameController.onExhale.Invoke();
        }
    }
}
