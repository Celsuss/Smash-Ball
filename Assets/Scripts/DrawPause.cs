/// <summary>
/// Draw pause text if game is paused.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrawPause : MonoBehaviour {
	
	[SerializeField] GameObject pauseMenu;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Check if the game is paused
		if (Time.timeScale == 0) 
			pauseMenu.SetActive(true);
		else 
			pauseMenu.SetActive(false);
	}
}