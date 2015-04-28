using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrawPause : MonoBehaviour {

	public Text PauseText;
	public GameObject PauseMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Check if the game is paused by checking Time.timeScale
		if (Time.timeScale == 0) {
			PauseMenu.SetActive(true);
			//PauseText.text = "Game Paused";
		}
		else {
			PauseMenu.SetActive(false);
			//PauseText.text = "";
		}
	}
}