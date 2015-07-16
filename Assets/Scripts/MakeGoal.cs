/// <summary>
/// Make goal if ball collides with object.
/// </summary>

using UnityEngine;
using System.Collections;

public class MakeGoal : MonoBehaviour {

	private GameObject PointManager;
	public GameObject Owner;

	// Use this for initialization
	void Start () {
		PointManager = GameObject.Find ("Manager");//;.GetComponent<PointsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Make a goal if ball collides with object.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag != "Ball")
			return;

		GameObject shooter = GetShooter (collision.gameObject).gameObject;

		if(shooter.Equals(Owner))
			Goal(collision.gameObject);  
	} 

	/// <summary>
	/// Find the player object that made the goal.
	/// </summary>
	/// <returns>The shooter.</returns>
	/// <param name="ball">Ball.</param>
	Transform GetShooter(GameObject ball){
		Transform parent;

		if (ball.transform.parent != null)
			parent = ball.transform.parent;
		else 
			parent = ball.GetComponent<GetParent> ().previousParent;

		return parent;
	}

	/// <summary>
	/// Add a point to the player object that made the goal.
	/// </summary>
	/// <param name="shooter">Shooter.</param>
	void Goal(GameObject shooter){
		PointManager.GetComponent<PointsManager> ().AddPoint (Owner);
	}
}
