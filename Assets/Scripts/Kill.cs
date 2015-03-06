using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnObject{
	public RespawnObject(GameObject obj, int t){
		RespawnObj = obj;
		RespawnTime = t;
	}
	public GameObject RespawnObj { get; set; }
	public float RespawnTime { get; set;}
}

public class Kill : MonoBehaviour {

	public int RespawnTime;

	private List<RespawnObject> RespawnList;

	// Use this for initialization
	void Start () {
		RespawnList = new List<RespawnObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		List<RespawnObject> deleteList = new List<RespawnObject> ();
		RespawnObjects (deleteList);
		RemoveRespawnedObjects (deleteList);
	}

	void RespawnObjects(List<RespawnObject> deleteList){
		foreach(RespawnObject robj in RespawnList){
			robj.RespawnTime -= Time.deltaTime;
			if(robj.RespawnTime <= 0){
				robj.RespawnObj.SetActive(true);
				robj.RespawnObj.GetComponent<Respawn>().ResetPos();
				deleteList.Add(robj);
			}
		}
	}

	void RemoveRespawnedObjects(List<RespawnObject> deleteList){
		foreach (RespawnObject robj in deleteList)
			RespawnList.Remove(robj);
	}

	void OnTriggerEnter2D (Collider2D collision) {
		if (collision.gameObject.tag == "Player") {
			RespawnList.Add (new RespawnObject(collision.gameObject, RespawnTime));
			RespawnChild(collision.gameObject);
			collision.gameObject.SetActive(false);
		}
		else if (collision.gameObject.tag == "Ball") {
			collision.gameObject.GetComponent<Respawn>().ResetPos();
		}
	}

	void RespawnChild(GameObject obj){
		Transform child = obj.transform.FindChild ("Ball");
		if (child != null)
			child.GetComponent<Respawn> ().ResetPos ();
	}
}