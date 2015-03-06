using UnityEngine;
using System.Collections;

public class MakeGoal : MonoBehaviour {

	public GameObject PointManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Ball")
			Goal(collision.gameObject);  
	} 

	void Goal(GameObject ball){
		Transform parent;
		if (ball.transform.parent != null)
			parent = ball.transform.parent;
		else 
			parent = ball.GetComponent<GetParent> ().PreviousParent;

		PointManager.GetComponent<PointsManager> ().AddPoint (parent.gameObject);
	}
}
