/// <summary>
/// Camera controller.
/// </summary>

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField] int offset;
	[SerializeField] float speed;
	GameObject[] players;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		startPos = transform.position;
	}
	
	/// <summary>
	/// Update this instance by zooming the camera in or out
	/// </summary>
	void Update () {
		if (!ZoomOut ())
			ZoomIn ();
	}

	/// <summary>
	/// Zooms out the camera.
	/// </summary>
	/// <returns><c>true</c>, if out was zoomed, <c>false</c> otherwise.</returns>
	bool ZoomOut(){
		//Vector3 cameraPos = transform.position;
		for (int i = 0; i < players.Length; i++) {
			Vector3 iPos = players[i].transform.position;
			Vector3 iScreenPos = Camera.main.WorldToScreenPoint(iPos);
			Vector2 screenSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);

			//Use deltaPos to zoom out
			//int deltaPos;

			//Zoom the camera out
			if (iScreenPos.x < (0 + offset) || iScreenPos.y < (0 + offset) ||
			    iScreenPos.x > (screenSize.x - offset) || iScreenPos.y > (screenSize.y - offset)){
				transform.Translate(new Vector3 (0, 0, -speed));
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Zooms in the camera.
	/// </summary>
	void ZoomIn(){
		Vector3 cameraPos = transform.position;
		for (int i = 0; i < players.Length; i++) {
			Vector3 iPos = players[i].transform.position;
			Vector3 iScreenPos = Camera.main.WorldToScreenPoint(iPos);
			Vector2 screenSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
			int offsetX2 = offset*2;

			//Zoom the camera in if true for all players
			if(cameraPos.z < startPos.z &&
			   ((iScreenPos.x > (0 + offsetX2) && iScreenPos.x < (screenSize.x - offsetX2)) && 
			 (iScreenPos.y > (0 + offsetX2) && iScreenPos.y < (screenSize.y - offsetX2)))){
			}
			else
				return;
		}
		transform.Translate(new Vector3 (0, 0, speed/*/2*/));
	}
}
