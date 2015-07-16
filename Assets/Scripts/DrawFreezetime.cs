/// <summary>
/// Draw freezetime.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawFreezetime : MonoBehaviour {

	[SerializeField] GameObject freezeTimeObject;
	Text freezeText;
	FreezeTime freezeTime;

	// Use this for initialization
	void Start () {
		freezeTime = freezeTimeObject.GetComponent<FreezeTime> ();
		freezeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get time left on freeze
		int timeLeft = freezeTime.GetTimeLeft ();

		//Dont write countdown if game is paused
		if (timeLeft > 0 && Time.timeScale != 0) 
			freezeText.text = timeLeft.ToString ();
		else
			freezeText.text = "";
	}
}