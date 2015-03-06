using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DrawPoints : MonoBehaviour {

	public GameObject PointManager;
	public List<Text> Texts;

	private PointsManager Points;
	private List<GameObject> Players;

	// Use this for initialization
	void Start () {
		Points = PointManager.GetComponent<PointsManager> ();
		Players = new List<GameObject> ();

		int i = 0;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Player")){
			Players.Add(obj);
			Texts[i].text = obj.name + ": 0";
			Debug.Log(obj.name);
			i++;
		}

		for (int i2 = i; i2 < 4; i2++) {
			Texts[i2].text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach (GameObject obj in Players) {
			int point = Points.GetPoint(obj);
			Texts[i].text = obj.name + ": " + point;
			i++;
			Debug.Log(obj.name);
		}
	}
}