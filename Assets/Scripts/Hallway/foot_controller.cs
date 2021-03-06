﻿using UnityEngine;
using System.Collections;

public class foot_controller : MonoBehaviour {
	public float speed = 2f;
	public Sprite second_foot;

	private bool downPhase = true,started = false,upPhase = false;
	private float timer = 0f;
	private float starting_y;
	private BoxCollider2D box_collider;
	private Vector3 shadow_location;
	private mirror_script mirror;

	void Awake(){
		box_collider = GetComponent<BoxCollider2D> ();
		mirror = GameObject.FindGameObjectWithTag ("mirror").GetComponent<mirror_script> ();
		starting_y = transform.position.y;
	}

	void Start(){
		box_collider.enabled = false;
		if (mirror.isMirrored){
			FlipGameObject(gameObject);
			SpriteRenderer r  = GetComponent<SpriteRenderer>();
			r.sprite = second_foot;
		}
	}

	void FlipGameObject(GameObject o){
		Vector3 scale = o.transform.localScale;
		scale.x *= -1;
		o.transform.localScale = scale;
	}

	public void SetShadowLocation(Vector3 loc){
		shadow_location = loc;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > shadow_location.y+1.4 && downPhase)
			transform.Translate (Vector3.down * Time.deltaTime *2* speed);
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
