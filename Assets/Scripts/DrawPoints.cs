/// <summary>
/// Draw all players points.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawPoints : MonoBehaviour {

	[SerializeField] GameObject PointManager;
	[SerializeField] List<Text> Texts;

	PointsManager Points;
	List<GameObject> Players;

	// Use this for initialization
	void Start () {
		Points = PointManager.GetComponent<PointsManager> ();
		Players = new List<GameObject> ();

		int i = 0;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Player")){
			Players.Add(obj);
			Texts[i].text = obj.name + ": 0";
			i++;
		}

		for (; i < 4; i++) {
			Texts[i].text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach (GameObject obj in Players) {
			int point = Points.GetPoint(obj);
			Texts[i].text = obj.name + ": " + point;
			i++;
		}
	}
}