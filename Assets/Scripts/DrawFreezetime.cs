using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawFreezetime : MonoBehaviour {

	public GameObject FreezeTimeObject;
	public Text FreezeText;

	private FreezeTime Freezetime;
	//private string EndFreezeStr;

	// Use this for initialization
	void Start () {
		Freezetime = FreezeTimeObject.GetComponent<FreezeTime> ();
		//EndFreezeStr = "Start!";
	}
	
	// Update is called once per frame
	void Update () {
		int timeLeft = Freezetime.GetTimeLeft ();

		if (timeLeft > 0) 
			FreezeText.text = timeLeft.ToString ();
		/*else if (timeLeft <= 0 && FreezeText.text != "") 
			FreezeText.text = EndFreezeStr;*/
		else
			FreezeText.text = "";
	}
}