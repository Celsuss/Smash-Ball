using UnityEngine;
using System.Collections;

public class MakeGoal : MonoBehaviour {

	private GameObject PointManager;
	//private Component PointManager;
	public GameObject Owner;

	// Use this for initialization
	void Start () {
		PointManager = GameObject.Find ("Manager");//;.GetComponent<PointsManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag != "Ball")
			return;

		GameObject shooter = GetShooter (collision.gameObject).gameObject;

		if(shooter.Equals(Owner))
			Goal(collision.gameObject);  
	} 

	Transform GetShooter(GameObject ball){
		Transform parent;

		if (ball.transform.parent != null)
			parent = ball.transform.parent;
		else 
			parent = ball.GetComponent<GetParent> ().PreviousParent;

		return parent;
	}

	void Goal(GameObject shooter){
		PointManager.GetComponent<PointsManager> ().AddPoint (Owner);
	}

	/*void Goal(GameObject ball){
		Transform parent;
		if (ball.transform.parent != null)
			parent = ball.transform.parent;
		else 
			parent = ball.GetComponent<GetParent> ().PreviousParent;

		PointManager.GetComponent<PointsManager> ().AddPoint (parent.gameObject);
	}*/
}
