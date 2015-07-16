/// <summary>
/// Make the camera follow targeted game object.
/// </summary>

using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	[SerializeField] Transform target;
	[SerializeField] int offset;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos0 = transform.position;
		Vector3 pos1 = target.transform.position;

		//Make the camera follow the player with an offset in x
		if (pos0.x < (pos1.x - offset)) {
			transform.Translate(new Vector3 (speed, 0, 0));
		}
		else if (pos0.x > pos1.x + offset) {
			transform.Translate(new Vector3 (-speed, 0, 0));
		}

		//Make the camera follow the player with an offset in y
		if (pos0.y < pos1.y - offset) {
			transform.Translate(new Vector3 (0, speed, 0));
		}
		else if (pos0.y > pos1.y + offset) {
			transform.Translate(new Vector3 (0, -speed, 0));
		}
	}
}