	using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

	private Animator Animator;

	private string ChargeInputAxis;
	private string XInputAxis;
	private string YInputAxis;

	public Transform Trail;
	public float TrailDistance;

	public int Power;

	public float ChargingTime;
	public float ChargeCooldown;
	public float PowerUpTime;

	private bool StartCharging;
	private bool PowerUp;
	private bool KeyPressed;

	private float ChargingClock;
	private float ChargeCooldownClock;
	private float PowerUpClock;

	private Quaternion OriginalRotation;

	// Use this for initialization
	void Start () {
		StartCharging = false;
		PowerUp = false;
		KeyPressed = false;

		ChargingClock = ChargingTime;
		ChargeCooldownClock = 0;
		PowerUpClock = PowerUpTime;

		OriginalRotation = transform.rotation;

		Animator = GetComponent<Animator> ();

		//Read input
		InputAxes input = GetComponent<InputAxes> ();
		ChargeInputAxis = input.Charge;
		XInputAxis = input.Run;
		YInputAxis = input.Jump;
	}
	
	// Update is called once per frame
	void Update () {
		ChargeCooldownClock -= Time.deltaTime;

		//Return if not ready yet
		if (ChargeCooldownClock > 0)
			return;

		//Start or end charging
		if(GetKeyPressed() && !PowerUp && !StartCharging)
			BeginPowerUp();
		else if (GetKeyPressed() && StartCharging)
			EndPowerUp ();

		//Countdown untill the charging is done and then shoot
		if(StartCharging && !PowerUp)
			ChargingPowerUp ();

		//Do the PowerUp
		if (PowerUp)
			UsePowerUp ();
	}

	bool GetKeyPressed(){
		if (Input.GetAxis (ChargeInputAxis) > 0 && !KeyPressed) {
			KeyPressed = true;
			return true;
		}
		else if (Input.GetAxis (ChargeInputAxis) <= 0 && KeyPressed)
			KeyPressed = false;

				
		return false;
	}

	void BeginPowerUp(){
		StartCharging = true;
		GetComponent<Collider2D>().isTrigger = true;
		GetComponent<Rigidbody2D>().isKinematic = true;
		Animator.SetBool("PowerupCharge", true);
	}

	void EndPowerUp(){
		StartCharging = false;
		GetComponent<Collider2D>().isTrigger = false;
		GetComponent<Rigidbody2D>().isKinematic = false;
		Animator.SetBool("PowerupCharge", false);
		ChargingClock = ChargingTime;
	}

	void ChargingPowerUp(){
		ChargingClock -= Time.deltaTime;
		
		if(ChargingClock < 0)
			FinishChargingPowerUp();
	}

	void FinishChargingPowerUp(){
		GetComponent<Collider2D>().isTrigger = false;
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().gravityScale = 0;

		StartCharging = false;
		ChargingClock = ChargingTime;
		
		Animator.SetBool("PowerupCharge", false);
		Animator.SetBool("Charge", true);

		PowerUp = true;
		ShootAway ();
	}

	void UsePowerUp(){
		PowerUpClock -= Time.deltaTime;
		if (PowerUpClock < 0) {
			PowerUpClock = PowerUpTime;
			Animator.SetBool("Charge", false);
			GetComponent<Rigidbody2D>().gravityScale = 1;
			ChargeCooldownClock = ChargeCooldown;
			PowerUp = false;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			transform.rotation = OriginalRotation;
			KillTrail();
		}
	}

	void KillTrail(){
		//Kill the child trail
		Transform trail = transform.FindChild ("Cloud(Clone)");
		if (trail != null)
			Destroy (trail.gameObject);
	}

	void ShootAway(){
		Vector2 angel = GetAngle ();

		if (angel.x == 0 && angel.y == 0)
			angel.y = 1;
		GetComponent<Rigidbody2D>().AddForce (angel * Power);

		float rotation = Mathf.Atan2(-angel.x, angel.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
		CreateTrail (angel);
	}

	void CreateTrail(Vector2 angel){
		Transform trail;
		Vector3 pos = transform.position;

		//Caclculate and set trail position
		Vector2 deltaPos = TrailDistance * angel;
		pos = new Vector3(pos.x - deltaPos.x, pos.y - deltaPos.y, 0);

		//Create the trail as a child
		trail = Instantiate (Trail, pos, Quaternion.identity) as Transform;
		trail.transform.SetParent (transform);

		//Set rotation on trail
		trail.transform.rotation = transform.rotation;

		//Reset trail localscale
		trail.transform.localScale = Trail.transform.localScale;
	}
	
	Vector2 GetAngle(){
		Vector2 angle = new Vector2 (0, 0);

		if(Input.GetAxis (YInputAxis) > 0)
			angle.y = 1;
		else if(Input.GetAxis (YInputAxis) < 0)
			angle.y = -1;
		
		if(Input.GetAxis (XInputAxis) > 0)
			angle.x = 1;
		else if(Input.GetAxis (XInputAxis) < 0)
			angle.x = -1;

		return angle;
	}
}
