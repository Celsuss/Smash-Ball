using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public Transform Target;
	public int Offset;
	public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos0 = transform.position;
		Vector3 pos1 = Target.transform.position;

		//Make the camera follow the player with an offset in x
		if (pos0.x < (pos1.x - Offset)) {
			transform.Translate(new Vector3 (Speed, 0, 0));
		}
		else if (pos0.x > pos1.x + Offset) {
			transform.Translate(new Vector3 (-Speed, 0, 0));
		}

		//Make the camera follow the player with an offset in y
		if (pos0.y < pos1.y - Offset) {
			transform.Translate(new Vector3 (0, Speed, 0));
		}
		else if (pos0.y > pos1.y + Offset) {
			transform.Translate(new Vector3 (0, -Speed, 0));
		}
	}
}
