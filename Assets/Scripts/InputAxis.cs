/// <summary>
/// Sets the names of the input axis for each player.
/// </summary>

using UnityEngine;
using System.Collections;

public class InputAxis : MonoBehaviour {

	public int Player;

	public string Run { get; set; }
	public string Jump { get; set; }
	public string Charge { get; set; }
	public string Kick { get; set; }

	// Use this for initialization
	void Start () {
		Run = "Run" + Player;
		Jump = "Jump" + Player;
		Charge = "Charge" + Player;
		Kick = "Kick" + Player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}