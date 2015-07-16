/// <summary>
/// Pause the game.
/// </summary>

using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Pause/unpause the game when escape is pressed
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (Time.timeScale == 1)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}

	/// <summary>
	/// Determines whether the game is paused.
	/// </summary>
	/// <returns><c>true</c> if this instance is paused; otherwise, <c>false</c>.</returns>
	public bool IsPaused(){
		if (Time.timeScale == 1)
			return false;
		return true;
	}

	/// <summary>
	/// Starts the pause.
	/// </summary>
	public void StartPause(){
		Time.timeScale = 0;
	}

	/// <summary>
	/// Ends the pause.
	/// </summary>
	public void EndPause(){
		Time.timeScale = 1;
	}
}