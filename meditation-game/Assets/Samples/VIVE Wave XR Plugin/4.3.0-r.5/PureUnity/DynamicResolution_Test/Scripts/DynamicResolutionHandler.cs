// "WaveVR SDK 
// © 2017 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the WaveVR SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class DynamicResolutionHandler : MonoBehaviour
{
	public Text textField;

	public void LoadMultiPassScene()
	{
		Debug.Log("DynamicResolution test load multipass scene");
		SceneManager.LoadScene("DynamicResolutionScene2_Test");
	}

	public void LoadSinglePassScene()
	{
		Debug.Log("DynamicResolution test load multipass scene");
		SceneManager.LoadScene("DynamicResolutionScene1_Test");
	}

	public void SetDefaultValue()//1
	{
		XRSettings.eyeTextureResolutionScale = 1;
		printScaleInfo(1);
	}

	public void SetMediumValue()
	{
		XRSettings.eyeTextureResolutionScale = 0.5f;
		printScaleInfo(0.5f);
	}

	public void SetLowValue()
	{
		XRSettings.eyeTextureResolutionScale = 0.3f;
		printScaleInfo(0.3f);
	}

	public void printScaleInfo(float value)
	{
		string str = string.Empty;
		str = "Scale : " + value.ToString();
		this.textField.text = str;
	}
}
