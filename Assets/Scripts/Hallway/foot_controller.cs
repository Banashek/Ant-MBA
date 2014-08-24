using UnityEngine;
using System.Collections;

public class foot_controller : MonoBehaviour {
	public float speed = 2f;
	private bool downPhase = true,started = false,upPhase = false;
	private float timer = 0f;
	private float starting_y;
	private BoxCollider2D box_collider;

	void Awake(){
		box_collider = GetComponent<BoxCollider2D> ();
		starting_y = transform.position.y;
	}

	void Start(){
		box_collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > starting_y-.7f && downPhase)
			transform.Translate (Vector3.down * Time.deltaTime * 2 * speed);
		else if (upPhase){
			box_collider.enabled=false;
			transform.Translate(Vector3.up*Time.deltaTime*speed);
			if(transform.position.y>starting_y+5f)
				Destroy (gameObject);
		}else{
			box_collider.enabled = true;
			downPhase = false;
			upPhase = true;
		}
	}
}
