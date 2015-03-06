using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Animator Animator;

	private string InputAxis;

	public int MoveForce;
	public int MaxSpeed;

	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator> ();
		//Read input
		InputAxis = GetComponent<InputAxes> ().Run;
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

		if (Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x) < MaxSpeed) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.right * direction * MoveForce);
		}
	}

	bool ChangeDirection(float direction){
		if (GetComponent<Rigidbody2D>().velocity.x == 0)
			return false;

		//If direction got another direction than current direction
		if ((direction > 0 && GetComponent<Rigidbody2D>().velocity.x < 0) ||
		    (direction < 0 && GetComponent<Rigidbody2D>().velocity.x > 0)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
			GetComponent<Rigidbody2D>().AddForce (Vector2.right * direction * MoveForce);
			return true;
		}
		return false;
	}

	void SetAnimationIsMoving(){
		if (GetComponent<Rigidbody2D>().velocity.x != 0)
			Animator.SetBool ("Moving", true);
		else
			Animator.SetBool ("Moving", false);
	}
}
