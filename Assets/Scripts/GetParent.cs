using UnityEngine;
using System.Collections;

public class GetParent : MonoBehaviour {

	public Transform previousParent { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Return if no current parent
		if (transform.parent == null) return;

		//Update the previous parent
		if (previousParent != transform.parent)
			previousParent = transform.parent;
	}
}
