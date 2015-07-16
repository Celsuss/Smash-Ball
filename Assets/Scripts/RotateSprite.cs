/// <summary>
/// Rotate the objects sprite.
/// </summary>

using UnityEngine;
using System.Collections;

public class RotateSprite : MonoBehaviour {

	private bool right;
	private bool left;

	// Use this for initialization
	void Start () {
		right = false;
		left = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D>().velocity.x > 0 && left) {
			float x = transform.localScale.x;
			float y = transform.localScale.y;
			float z = transform.localScale.z;
			transform.localScale = new Vector3(-x, y, z);
			left = false;
			right = true;
		}
		else if (GetComponent<Rigidbody2D>().velocity.x < 0 && right) {
			float x = transform.localScale.x;
			float y = transform.localScale.y;
			float z = transform.localScale.z;
			transform.localScale = new Vector3(-x, y, z);
			right = false;
			left = true;
		}
	}
}
