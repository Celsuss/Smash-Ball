/// <summary>
/// Fixes a bug where the ball object changes size.
/// </summary>

using UnityEngine;
using System.Collections;

public class KeepBallSize : MonoBehaviour {

	private Vector3 Scale;

	// Use this for initialization
	void Start () {
		Scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		//Ball keeps changing scale when it loses a parent
		if (transform.parent != null) {
			transform.localScale = Scale/3;
		}
	}
}
