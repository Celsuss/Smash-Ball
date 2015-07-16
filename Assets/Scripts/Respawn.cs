/// <summary>
/// Respawn an object.
/// </summary>

using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	private Vector3 SpawnPosition { get; set; }

	// Use this for initialization
	void Start () {
		SpawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Set the respawned objects position to it's start position.
	/// </summary>
	public void ResetPos(){
		transform.position = SpawnPosition;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);

		if (transform.parent != null)
			transform.parent = null;

		if (GetComponent<Collider2D>().isTrigger)
			GetComponent<Collider2D>().isTrigger = false;

		if (GetComponent<Rigidbody2D>().isKinematic)
			GetComponent<Rigidbody2D>().isKinematic = false;
	}
}