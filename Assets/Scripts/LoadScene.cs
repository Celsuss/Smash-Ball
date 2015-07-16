/// <summary>
/// Load scene.
/// </summary>

using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load(){
		Application.LoadLevel ("sceneOne");
	}

	public void LoadStartMenu(){
		Application.LoadLevel ("Menu");
	}
}