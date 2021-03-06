﻿/// <summary>
/// Read input and moves the object.
/// </summary>

using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public int MoveForce;
	public int MaxSpeed;

	private Animator Animator;
	private string InputAxis;
	private Rigidbody2D rbdy2D;

	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator> ();
		InputAxis = GetComponent<InputAxis> ().Run;
		rbdy2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetAnimationIsMoving ();
	}

	void FixedUpdate(){
		//Read input and add force to left or right
		float direction = Input.GetAxis (InputAxis);

		if (ChangeDirection (direction))
			return;

		if (Mathf.Abs (rbdy2D.velocity.x) < MaxSpeed) {
			rbdy2D.AddForce (Vector2.right * direction * MoveForce);
		}
	}

	/// <summary>
	/// Changes the direction of the object.
	/// </summary>
	/// <returns><c>true</c>, if direction was changed, <c>false</c> otherwise.</returns>
	/// <param name="direction">Direction.</param>
	bool ChangeDirection(float direction){
		if (GetComponent<Rigidbody2D>().velocity.x == 0)
			return false;

		//If direction got another direction than current direction
		if ((direction > 0 && rbdy2D.velocity.x < 0) ||
		    (direction < 0 && rbdy2D.velocity.x > 0)) {
			rbdy2D.velocity = new Vector2(0, rbdy2D.velocity.y);
			rbdy2D.AddForce (Vector2.right * direction * MoveForce);
			return true;
		}
		return false;
	}

	/// <summary>
	/// Sets the animation to Moving.
	/// </summary>
	void SetAnimationIsMoving(){
		if (rbdy2D.velocity.x != 0)
			Animator.SetBool ("Moving", true);
		else
			Animator.SetBool ("Moving", false);
	}
}
