using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawFreezetime : MonoBehaviour {

	public GameObject FreezeTimeObject;
	public Text FreezeText;

	private FreezeTime Freezetime;

	// Use this for initialization
	void Start () {
		Freezetime = FreezeTimeObject.GetComponent<FreezeTime> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Get time left on freeze
		int timeLeft = Freezetime.GetTimeLeft ();

		//Dont write countdown if game is paused
		if (timeLeft > 0 && Time.timeScale != 0) 
			FreezeText.text = timeLeft.ToString ();
		else
			FreezeText.text = "";
	}
}