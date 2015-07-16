/// <summary>
/// Freeze time, during time is freezed then no game object can move.
/// </summary>

using UnityEngine;
using System.Collections;

public class FreezeTime : MonoBehaviour {

	[SerializeField] float freezeTime;
	float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = freezeTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0) 
			timeLeft -= Time.deltaTime;
	}

	/// <summary>
	/// Starts the freezetime countdown.
	/// </summary>
	public void StartCountdown(){
		timeLeft = freezeTime;
	}

	/// <summary>
	/// Gets the time left of freezetime.
	/// </summary>
	/// <returns>The time left.</returns>
	public int GetTimeLeft(){
		return (int)timeLeft;
	}

	/// <summary>
	/// Returns true if time is frozen.
	/// </summary>
	/// <returns><c>true</c>, if is freeze was gotten, <c>false</c> otherwise.</returns>
	public bool GetIsFreeze(){
		if ((int)timeLeft > 0) 
			return true;
		return false;
	}
}