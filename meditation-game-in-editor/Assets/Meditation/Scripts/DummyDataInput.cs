using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyDataInput : MonoBehaviour
{
	List<Dictionary<string, object>> data;
	GameController gameController;
	int row = 0; //timestamp
	// Start is called before the first frame update
	void Awake()
	{
		gameController = GetComponent<GameController>();
		data = CSVReader.Read(Application.streamingAssetsPath+"/breathing_1.csv");
		
		//for (int i = 0; i < data.Count; i++)
		//{
		//	print("time " + data[i]["Time"] + " " +
		//		   "resperation " + data[i]["Data"] + " " );
		//}

	}

	bool isBreathin(int timestamp)
    {
		if (timestamp >= 0)
        {
			Debug.Log((bool)(data[timestamp]["data"]));
			return (bool)(data[timestamp]["data"]);
		}
		else return false;
    }

	bool isBreathin()
	{
		if (row >= 0)
		{
			if (data[row]["Data"].Equals(1))
				return true;
			else return false;
		}
		else return false;
	}

	void BreathSignals()
    {
        if (isBreathin())
        {
			gameController.onInhale.Invoke();
		}

        else
        {
			gameController.onExhale.Invoke();
		}
			

    }

	void Start()
    {
		InvokeRepeating("BreathSignals", 0, 0.1f);
	}
}
