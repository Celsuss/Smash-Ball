using UnityEngine;
using System.Collections;

public class GrabBall : MonoBehaviour {

	private Animator Animator;

	AnimatorStateInfo LastAnimationState;

	public float BallOffsetY;
	public float BallOffsetX;

	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Transform ball = transform.FindChild ("Ball");
		if (ball == null) return;
		DropBallIfCharge (ball);
		UpdateBallPosition (ball);
	}

	//Grab the ball if collision
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.name == "Ball" && col.transform.parent == null) {
			col.transform.SetParent (transform);

			col.transform.GetComponent<Collider2D>().isTrigger = true;
			col.transform.GetComponent<Rigidbody2D>().isKinematic = true;

			if(!Animator.GetBool ("Charge"))
				PlaceBallBeforePlayer (col.transform);
		}
	}

	void PlaceBallBeforePlayer(Transform ball){
		Vector2 pos = transform.position;
		pos.y += BallOffsetY;

		if (ball.position.x > pos.x)
			pos.x += BallOffsetX;
		else
			pos.x -= BallOffsetX;

		ball.position = new Vector3 (pos.x, pos.y, 0);
	}

	void UpdateBallPosition(Transform ball){
		AnimatorStateInfo currentAnimationState = Animator.GetCurrentAnimatorStateInfo (0);

		if (!currentAnimationState.Equals(LastAnimationState)) {
			Vector2 pos = transform.position;
			float currentDirectionX = GetCurrentDirectionX ();

			if(currentDirectionX != 0)
				pos.x += currentDirectionX > 0 ? BallOffsetX : -BallOffsetX;
			else
				pos.x = ball.position.x;

			pos.y += BallOffsetY;
			ball.position = new Vector3 (pos.x, pos.y, 0);
		}

		LastAnimationState = currentAnimationState;
	}

	void DropBallIfCharge(Transform ball){
		if(Animator.GetBool("PowerupCharge")){
			ball.transform.SetParent(null);
			ball.GetComponent<Collider2D>().isTrigger = false;
			ball.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	float GetCurrentDirectionX(){
		float direction;
		direction = GetComponent<Rigidbody2D>().velocity.x;

		if (direction == 0)
			return 0;
		return direction > 0 ? 1 : -1;
	}
}
