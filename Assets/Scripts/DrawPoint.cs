/// <summary>
/// Draw a players point.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrawPoint : MonoBehaviour {

	[SerializeField] GameObject PointManager;
	[SerializeField] string PlayerName;

	Text PointText;
	GameObject Player;
	PointsManager Points;

	// Use this for initialization
	void Start () {
		Points = PointManager.GetComponent<PointsManager> ();
		PointText = GetComponent<Text> ();

		Player = GameObject.Find (PlayerName);
		if (Player != null)
			PointText.text = PlayerName + ": 0";
		else
			PointText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (Player != null) {
			int point = Points.GetPoint (Player);
			PointText.text = PlayerName + ": " + point;
		}
	}
}