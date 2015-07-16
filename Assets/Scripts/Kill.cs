/// <summary>
/// Kills a object that collides with this object and respawn that object at it's starting position.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A class that holds dead objects and the objects respawn time.
/// </summary>
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

	/// <summary>
	/// Respawns all dead objects.
	/// </summary>
	/// <param name="deleteList">Delete list.</param>
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

	/// <summary>
	/// Removes objects from the respawn list.
	/// </summary>
	/// <param name="deleteList">Delete list.</param>
	void RemoveRespawnedObjects(List<RespawnObject> deleteList){
		foreach (RespawnObject robj in deleteList)
			RespawnList.Remove(robj);
	}

	/// <summary>
	/// Kill objects that collide with this object.
	/// </summary>
	/// <param name="collision">Collision.</param>
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

	/// <summary>
	/// Respawns the child of a dead object.
	/// </summary>
	/// <param name="obj">Object.</param>
	void RespawnChild(GameObject obj){
		Transform child = obj.transform.FindChild ("Ball");
		if (child != null)
			child.GetComponent<Respawn> ().ResetPos ();
	}
}