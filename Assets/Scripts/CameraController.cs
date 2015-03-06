using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public int Offset;
	public float Speed;

	private GameObject[] Players;
	private Vector3 StartPos;

	// Use this for initialization
	void Start () {
		Players = GameObject.FindGameObjectsWithTag ("Player");
		StartPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Dont zoom in and out in the same update
		if (!ZoomOut ())
			ZoomIn ();
	}

	bool ZoomOut(){
		//Vector3 cameraPos = transform.position;
		for (int i = 0; i < Players.Length; i++) {
			Vector3 iPos = Players[i].transform.position;
			Vector3 iScreenPos = Camera.main.WorldToScreenPoint(iPos);
			Vector2 screenSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);

			//Use deltaPos to zoom out
			//int deltaPos;

			//Zoom the camera out
			if (iScreenPos.x < (0 + Offset) || iScreenPos.y < (0 + Offset) ||
			    iScreenPos.x > (screenSize.x - Offset) || iScreenPos.y > (screenSize.y - Offset)){
				transform.Translate(new Vector3 (0, 0, -Speed));
				return true;
			}
		}
		return false;
	}

	void ZoomIn(){
		Vector3 cameraPos = transform.position;
		for (int i = 0; i < Players.Length; i++) {
			Vector3 iPos = Players[i].transform.position;
			Vector3 iScreenPos = Camera.main.WorldToScreenPoint(iPos);
			Vector2 screenSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
			int offset = Offset*2;

			//Zoom the camera in if true for all players
			if(cameraPos.z < StartPos.z &&
			((iScreenPos.x > (0 + offset) && iScreenPos.x < (screenSize.x - offset)) && 
			(iScreenPos.y > (0 + offset) && iScreenPos.y < (screenSize.y - offset)))){
			}
			else
				return;
		}
		transform.Translate(new Vector3 (0, 0, Speed/*/2*/));
	}
}
