/// <summary>
/// Enables the object to steal the ball from another object that is holding the ball.
/// </summary>

using UnityEngine;
using System.Collections;

public class StealBall : MonoBehaviour {

	private Animator Animator;

	public float BallOffsetY;

	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// If collide with another object, determines if the ball can be stolen. If true then steal the ball.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter2D(Collision2D collision){
		//Return if can't steal
		if (!CanStealBall(collision)) return;

		Steal (collision);
	}

	/// <summary>
	/// Determines whether this object can steal the ball from another object.
	/// </summary>
	/// <returns><c>true</c> if this instance can steal ball the specified collision; otherwise, <c>false</c>.</returns>
	/// <param name="collision">Collision.</param>
	bool CanStealBall(Collision2D collision){
		//If not charging then return
		if (!Animator.GetBool ("Charge"))
			return false;
		
		//If collision object is not a player
		if (collision.gameObject.tag != "Player")
			return false;
		
		//If object is kinematic then return
		if (collision.gameObject.GetComponent<Rigidbody2D>().isKinematic)
			return false;
		
		Transform ball = collision.transform.FindChild ("Ball");
		//If collision object dont got the ball then return
		if (ball == null)
			return false;

		return true;
	}

	/// <summary>
	/// Steal the ball from another object.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void Steal(Collision2D collision){
		Transform ball = collision.transform.FindChild ("Ball");
		if(ball == null) return;

		ball.parent = this.transform;

		PlaceBallBeforePlayer (ball);
	}

	/// <summary>
	/// Places the ball before the object.
	/// </summary>
	/// <param name="ball">Ball.</param>
	void PlaceBallBeforePlayer(Transform ball){
		Vector2 pos = transform.position;
		pos.y += BallOffsetY;
		ball.position = new Vector3 (pos.x, pos.y, 0);
	}
}
