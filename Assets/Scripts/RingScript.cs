using UnityEngine;
using System.Collections;

public class RingScript : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D coll)	{
		if (coll.gameObject.name == "stupidant") {
			Debug.Log("Player touched ring");
			Application.LoadLevel("Wheres That Ant");
		}
	}
}
