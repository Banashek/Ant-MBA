using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {

	public Sprite pressed_button;

	private Sprite button_default;
	private Collider2D collider;
	private SpriteRenderer r;
	// Use this for initialization
	void Awake () {
		collider = GetComponent<Collider2D> ();
		r = GetComponent<SpriteRenderer> ();
		button_default = r.sprite;
	}
	
	void OnMouseDown(){
		r.sprite = pressed_button;
	}

	void OnMouseUp(){
		Debug.Log ("begin game");
		r.sprite = button_default;
		Application.LoadLevel ("Opening Cut Scene");
	}
}
