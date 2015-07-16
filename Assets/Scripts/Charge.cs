/// <summary>
/// Controlls game objects charge.
/// </summary>

using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

	[SerializeField] Transform spawnTrail;
	[SerializeField] float trailDistance;
	[SerializeField] int power;
	[SerializeField] float chargingTime;
	[SerializeField] float chargeCooldown;
	[SerializeField] float chargeTime;

	Animator animator;

	Transform trail;
	
	string chargeInputAxis;
	string xInputAxis;
	string yInputAxis;

	bool charging;
	bool powerUp;
	bool keyPressed;

	float chargingClock;
	float ChargeCooldownClock;
	float chargeClock;

	Quaternion originalRotation;

	// Use this for initialization
	void Start () {
		charging = false;
		powerUp = false;
		keyPressed = false;

		chargingClock = chargingTime;
		ChargeCooldownClock = 0;
		chargeClock = chargeTime;

		originalRotation = transform.rotation;

		animator = GetComponent<Animator> ();

		//Read input
		InputAxis input = GetComponent<InputAxis> ();
		chargeInputAxis = input.Charge;
		xInputAxis = input.Run;
		yInputAxis = input.Jump;
	}
	
	// Update is called once per frame
	void Update () {
		if (ChargeCooldownClock > 0) {
			ChargeCooldownClock -= Time.deltaTime;
			return;
		}

		if (GetKeyPressed ()) {
			if(!charging && !powerUp)
				BeginPowerUp();
			else if(charging)
				CancelPowerUp();
		}

		//Countdown untill the charging is done and then shoot
		if(charging && !powerUp)
			ChargingPowerUp ();

		//Do the PowerUp
		if (powerUp)
			Charging ();
	}

	/// <summary>
	/// Returns true if charge button is pressed else return false.
	/// </summary>
	/// <returns><c>true</c>, if key pressed, <c>false</c> otherwise.</returns>
	bool GetKeyPressed(){
		if (Input.GetAxis (chargeInputAxis) > 0 && !keyPressed) {
			keyPressed = true;
			return true;
		}
		else if (Input.GetAxis (chargeInputAxis) <= 0 && keyPressed)
			keyPressed = false;

		return false;
	}

	/// <summary>
	/// Begins the power up of charge.
	/// </summary>
	void BeginPowerUp(){
		charging = true;
		GetComponent<Collider2D>().isTrigger = true;
		GetComponent<Rigidbody2D>().isKinematic = true;
		animator.SetBool("PowerupCharge", true);
	}

	/// <summary>
	/// Cancels the power up of charge.
	/// </summary>
	/// <returns><c>true</c> if this instance cancel power up; otherwise, <c>false</c>.</returns>
	void CancelPowerUp(){
		charging = false;
		GetComponent<Collider2D>().isTrigger = false;
		GetComponent<Rigidbody2D>().isKinematic = false;
		animator.SetBool("PowerupCharge", false);
		chargingClock = chargingTime;
	}

	/// <summary>
	/// Count down the power up, if clock reaches zero then call FinishChargingPowerUp().
	/// </summary>
	void ChargingPowerUp(){
		chargingClock -= Time.deltaTime;
		
		if(chargingClock < 0)
			FinishChargingPowerUp();
	}

	/// <summary>
	/// Finishs the charging power up and start the charge.
	/// </summary>
	void FinishChargingPowerUp(){
		GetComponent<Collider2D>().isTrigger = false;
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().gravityScale = 0;

		charging = false;
		chargingClock = chargingTime;
		
		animator.SetBool("PowerupCharge", false);
		animator.SetBool("Charge", true);

		powerUp = true;
		StartCharge ();
	}

	/// <summary>
	/// Calls if charging and count down the charge time. if time reaches zero then end charge and kill trail.
	/// </summary>
	void Charging(){
		chargeClock -= Time.deltaTime;
		if (chargeClock < 0) {
			chargeClock = chargeTime;
			animator.SetBool("Charge", false);
			GetComponent<Rigidbody2D>().gravityScale = 1;
			ChargeCooldownClock = chargeCooldown;
			powerUp = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			transform.rotation = originalRotation;
			KillTrail();
		}
	}

	/// <summary>
	/// Kills the trail after charge.
	/// </summary>
	void KillTrail(){
		if (trail != null) {
			Destroy (trail.gameObject);
			trail = null;
		}
	}

	/// <summary>
	/// Starts the charge.
	/// </summary>
	void StartCharge(){
		Vector2 angel = GetAngle ();

		if (angel.x == 0 && angel.y == 0)
			angel.y = 1;
		GetComponent<Rigidbody2D>().AddForce (angel * power);

		float rotation = Mathf.Atan2(-angel.x, angel.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
		CreateTrail (angel);
	}

	/// <summary>
	/// Creates the trail when charge starts.
	/// </summary>
	/// <param name="angel">Angel.</param>
	void CreateTrail(Vector2 angel){
		Transform newTrail;
		Vector3 pos = transform.position;

		//Caclculate and set trail position
		Vector2 deltaPos = trailDistance * angel;
		pos = new Vector3(pos.x - deltaPos.x, pos.y - deltaPos.y, 0);

		//Create the trail as a child
		newTrail = Instantiate (spawnTrail, pos, Quaternion.identity) as Transform;
		newTrail.transform.SetParent (transform);

		//Set rotation on trail
		newTrail.transform.rotation = transform.rotation;

		//Reset trail localscale
		newTrail.transform.localScale = spawnTrail.transform.localScale;

		trail = newTrail;
	}

	/// <summary>
	/// Gets the angle of game object
	/// </summary>
	/// <returns>The angle.</returns>
	Vector2 GetAngle(){
		Vector2 angle = new Vector2 (0, 0);

		if(Input.GetAxis (yInputAxis) > 0)
			angle.y = 1;
		else if(Input.GetAxis (yInputAxis) < 0)
			angle.y = -1;
		
		if(Input.GetAxis (xInputAxis) > 0)
			angle.x = 1;
		else if(Input.GetAxis (xInputAxis) < 0)
			angle.x = -1;

		return angle;
	}
}
