/// <summary>
/// Read input and lets a game object kick.
/// </summary>

using UnityEngine;
using System.Collections;

public class Kick : MonoBehaviour {

	private Animator Animator;

	private string KickInputAxis;
	private string YInputAxis;

	public int Force;
	private int CurrentDirectionX;

	private AudioSource Audio;
	[SerializeField] private AudioClip Sound;

	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator> ();
		Audio = GetComponent<AudioSource>();
		InputAxis input = GetComponent<InputAxis> ();
		KickInputAxis = input.Kick;
		YInputAxis = input.Jump;
		CurrentDirectionX = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Animator.SetBool("Kick", false);

		UpdateDirection ();

		if (Input.GetAxis (KickInputAxis) > 0) {
			Animator.SetBool("Kick", true);
			KickBall();
		}
	}

	/// <summary>
	/// Updates the direction of the object and the direction of the kick.
	/// </summary>
	void UpdateDirection(){
		if (GetComponent<Rigidbody2D>().velocity.x < 0 && CurrentDirectionX != -1)
			CurrentDirectionX = -1;
		else if (GetComponent<Rigidbody2D>().velocity.x > 0 && CurrentDirectionX != 1)
			CurrentDirectionX = 1;
	}

	/// <summary>
	/// Kicks the ball the object is holding the ball.
	/// </summary>
	void KickBall(){
		Transform ball = transform.FindChild ("Ball");
		if (ball == null) return;

		//If not holding the ball then dont kick the ball
		if (!HoldingBall (ball))
			return;

		ball.transform.SetParent(null);
		ball.GetComponent<Collider2D>().isTrigger = false;
		ball.GetComponent<Rigidbody2D>().isKinematic = false;

		//Audio.Play();
		Audio.PlayOneShot(Sound, 1);

		//If down key is down then drop ball
		if (Input.GetAxis (YInputAxis) < 0) {
			ball.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 0));
		}
		else {
			Vector2 totalForce = new Vector2 (CurrentDirectionX, 1) * Force;
			ball.GetComponent<Rigidbody2D>().AddForce (totalForce);
		}
	}

	/// <summary>
	/// Check if the ball is a child to this object, if true then object is holding the ball.
	/// </summary>
	/// <returns><c>true</c>, if ball was holdinged, <c>false</c> otherwise.</returns>
	/// <param name="ball">Ball.</param>
	bool HoldingBall(Transform ball){
		if (ball.parent == transform)
			return true;
		
		return false;
	}
}
