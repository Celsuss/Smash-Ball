/// <summary>
/// Enable game object to grab ball, if ball is grabbed then makes it child of game object that grabed it.
/// </summary>

using UnityEngine;
using System.Collections;

public class GrabBall : MonoBehaviour {

	[SerializeField] float ballOffsetY;	//-0.45
	[SerializeField] float ballOffsetX;	//0.7
	Animator animator;
	AnimatorStateInfo lastAnimationState;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Transform ball = transform.FindChild ("Ball");
		if (ball == null) return;
		DropBallIfCharge (ball);
		//UpdateBallPosition (ball);
		PlaceBallBeforePlayer (ball);
	}

	/// <summary>
	/// Grabs the ball and sets it as child if collided with game object
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.name == "Ball" && col.transform.parent == null) {
			col.transform.SetParent (transform);

			col.transform.GetComponent<Collider2D>().isTrigger = true;
			col.transform.GetComponent<Rigidbody2D>().isKinematic = true;

			if(!animator.GetBool ("Charge"))
				PlaceBallBeforePlayer (col.transform);
		}
	}

	/// <summary>
	/// Places the ball before player.
	/// </summary>
	/// <param name="ball">Ball.</param>
	void PlaceBallBeforePlayer(Transform ball){
		Vector2 pos = transform.position;
		pos.y += ballOffsetY;

		if (ball.position.x > pos.x)
			pos.x += ballOffsetX;
		else
			pos.x -= ballOffsetX;

		ball.position = new Vector3 (pos.x, pos.y, 0);
	}

	/*void UpdateBallPosition(Transform ball){
		AnimatorStateInfo currentAnimationState = animator.GetCurrentAnimatorStateInfo (0);

		if (!currentAnimationState.Equals(lastAnimationState)) {
			Vector2 pos = transform.position;
			float currentDirectionX = GetCurrentDirectionX ();

			if(currentDirectionX != 0)
				pos.x += currentDirectionX > 0 ? ballOffsetX : -ballOffsetX;
			else
				pos.x = ball.position.x;

			pos.y += ballOffsetY;
			ball.position = new Vector3 (pos.x, pos.y, 0);
		}

		lastAnimationState = currentAnimationState;
	}*/

	/// <summary>
	/// Drops the ball if chargeing, removes ball as child.
	/// </summary>
	/// <param name="ball">Ball.</param>
	void DropBallIfCharge(Transform ball){
		if(animator.GetBool("PowerupCharge")){
			ball.transform.SetParent(null);
			ball.GetComponent<Collider2D>().isTrigger = false;
			ball.GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}

	/*float GetCurrentDirectionX(){
		float direction;
		direction = GetComponent<Rigidbody2D>().velocity.x;

		if (direction == 0)
			return 0;
		return direction > 0 ? 1 : -1;
	}*/
}
