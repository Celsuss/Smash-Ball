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

	// Returns true if game is paused
	public bool IsPaused(){
		if (Time.timeScale == 1)
			return false;
		return true;
	}

	// Pauses the game
	public void StartPause(){
		Time.timeScale = 0;
	}

	// End pause
	public void EndPause(){
		Time.timeScale = 1;
	}
}