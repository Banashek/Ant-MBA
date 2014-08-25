using UnityEngine;
using System.Collections;

public class saw_spin : MonoBehaviour {

	public float speed;
	private int direction = 1;

	void Start(){
		if(Random.Range(1,1000)>500)
			direction = -1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, Vector3.forward, direction*Time.deltaTime*speed);
	}
}
