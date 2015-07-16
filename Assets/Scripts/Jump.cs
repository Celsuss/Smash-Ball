/// <summary>
/// Read input and lets a game object jump.
/// </summary>

using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	private Animator Animator;

	private string InputAxis;

	public int JumpForce;
	public int MaxJumpForce;
	public int MaxJumps;
	private int JumpCount;
	
	private float RayLength;
	private Rigidbody2D rbdy2D;

	// Use this for initialization
	void Start () {
		JumpCount = MaxJumps;
		Animator = GetComponent<Animator> ();
		RayLength = 1.2f;
		InputAxis = GetComponent<InputAxis> ().Jump;
		rbdy2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!Animator.GetBool("Jump")){
			JumpCount = MaxJumps;
		}
		IsOnGround ();
	}

	/// <summary>
	/// Check input and makes the game object jump.
	/// </summary>
	void FixedUpdate(){
		//Read input and add force to left or right
		if (Input.anyKeyDown && JumpCount > 0 && rbdy2D.velocity.y < MaxJumpForce && Input.GetAxis(InputAxis) > 0) {
			rbdy2D.velocity = new Vector2(rbdy2D.velocity.x, 0);
			rbdy2D.AddForce (Vector2.up * JumpForce);
			Animator.SetBool("Jump", true);
			JumpCount--;	
		}
	}

	/// <summary>
	/// Determines whether the game object is on ground.
	/// </summary>
	/// <returns><c>true</c> if this instance is on ground; otherwise, <c>false</c>.</returns>
	void IsOnGround(){
		RaycastHit2D ray = Physics2D.Raycast(transform.position, -Vector2.up, RayLength, 1 << LayerMask.NameToLayer("Walls"));
			
		//If ray hits something then stop jump animation
		if (ray.collider != null) 
			Animator.SetBool ("Jump", false);
		else
			Animator.SetBool ("Jump", true);
	}
}
