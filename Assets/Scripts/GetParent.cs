using UnityEngine;
using System.Collections;

public class GetParent : MonoBehaviour {

	public Transform PreviousParent { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Return if no current parent
		if (transform.parent == null) return;

		//Update the previous parent
		if (PreviousParent != transform.parent)
			PreviousParent = transform.parent;
	}
}
