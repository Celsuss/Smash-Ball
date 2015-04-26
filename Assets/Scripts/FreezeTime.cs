using UnityEngine;
using System.Collections;

public class FreezeTime : MonoBehaviour {

	public float Freezetime;

	private float TimeLeft;

	// Use this for initialization
	void Start () {
		TimeLeft = Freezetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeLeft > 0) 
			TimeLeft -= Time.deltaTime;
	}

	public void StartCountdown(){
		TimeLeft = Freezetime;
	}

	public int GetTimeLeft(){
		return (int)TimeLeft;
	}

	public bool GetIsFreeze(){
		if ((int)TimeLeft > 0) 
			return true;
		return false;
	}
}