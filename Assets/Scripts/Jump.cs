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

	// Use this for initialization
	void Start () {
		JumpCount = MaxJumps;
		Animator = GetComponent<Animator> ();
		RayLength = 1.2f;
		InputAxis = GetComponent<InputAxes> ().Jump;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Animator.GetBool("Jump")){
			JumpCount = MaxJumps;
		}
		IsOnGround ();
	}

	void FixedUpdate(){
		//Read input and add force to left or right
		if (Input.anyKeyDown && JumpCount > 0 && GetComponent<Rigidbody2D>().velocity.y < MaxJumpForce && Input.GetAxis(InputAxis) > 0) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * JumpForce);
			Animator.SetBool("Jump", true);
			JumpCount--;	
		}
	}

	void IsOnGround(){
		RaycastHit2D ray = Physics2D.Raycast(transform.position, -Vector2.up, RayLength);
			
		//If ray hits something then stop jump animation
		if (ray.collider != null) 
			Animator.SetBool ("Jump", false);
		else
			Animator.SetBool ("Jump", true);
	}
}
