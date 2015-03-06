using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointsManager : MonoBehaviour {

	Dictionary<string, int> Points;
	
	// Use this for initialization
	void Start () {
		Points = new Dictionary<string, int> ();
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Player");

		for (int i = 0; i < objs.Length; i++) 
			Points.Add (objs[i].name, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("PlayerOne: " + Points["PlayerOne"]);
		//Debug.Log ("PlayerTwo: " + Points["PlayerTwo"]);
	}

	void RespawnObjects(){
		foreach(GameObject obj in GameObject.FindObjectsOfType<GameObject>()){
			Component respawn = obj.GetComponent<Respawn>();
			if(respawn != null)
				((Respawn)respawn).ResetPos();
		}
	}

	public void AddPoint(GameObject obj){
		Points [obj.name]++;
		RespawnObjects ();
	}

	public int GetPoint(GameObject obj){
		return Points [obj.name];
	}
}
