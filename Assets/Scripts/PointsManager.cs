/// <summary>
/// Manages all players points.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointsManager : MonoBehaviour {

	private Dictionary<string, int> Points;
	private FreezeTime Freezetime;	
	
	// Use this for initialization
	void Start () {
		Points = new Dictionary<string, int> ();
		Freezetime = GetComponent<FreezeTime> ();

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Player");

		for (int i = 0; i < objs.Length; i++) 
			Points.Add (objs[i].name, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Freezetime.GetIsFreeze())
			RespawnObjects();
		//Debug.Log ("PlayerOne: " + Points["PlayerOne"]);
		//Debug.Log ("PlayerTwo: " + Points["PlayerTwo"]);
	}

	/// <summary>
	/// Respawns all the player objects if a goal was made.
	/// </summary>
	void RespawnObjects(){
		foreach(GameObject obj in GameObject.FindObjectsOfType<GameObject>()){
			Component respawn = obj.GetComponent<Respawn>();
			if(respawn != null)
				((Respawn)respawn).ResetPos();
		}
	}

	/// <summary>
	/// Adds a point to a player.
	/// </summary>
	/// <param name="obj">Object.</param>
	public void AddPoint(GameObject obj){
		Points [obj.name]++;
		RespawnObjects ();
		Freezetime.StartCountdown ();
	}

	/// <summary>
	/// Get a players points.
	/// </summary>
	/// <returns>The point.</returns>
	/// <param name="obj">Object.</param>
	public int GetPoint(GameObject obj){
		return Points [obj.name];
	}
}
