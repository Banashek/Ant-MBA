using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {

	public Sprite key_up,key_down;
	public string value;

	private AudioSource keyupsound, keydownsound;
	private float time_on_key = 0f;
	private keyboard kb;
	// Use this for initialization
	void Awake () {
		GetComponent<SpriteRenderer> ().sprite = key_up;
		kb = GameObject.FindGameObjectWithTag ("keyboard").GetComponent<keyboard> ();
		keyupsound = GameObject.Find ("keyupsound").GetComponent<AudioSource> ();
		keydownsound = GameObject.Find ("keydownsound").GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter2D(){
		Debug.Log ("Collision");
		GetComponent<SpriteRenderer> ().sprite = key_down;
		if (!value.Equals ("ENTER") && kb.keys_entered<40 ){
			kb.name = kb.name.Substring(0,kb.name.Length-1)+value+"_";
			kb.keys_entered += 1;
		}
		keydownsound.Play ();
		if (value.Equals ("ENTER"))
			Application.LoadLevel("Post Typing Cutscene");
	}

	void OnTriggerStay2D(){
		if(time_on_key>.5f && !value.Equals ("ENTER") && kb.keys_entered<40){
			kb.name = kb.name.Substring(0,kb.name.Length-1)+value+"_";
			kb.keys_entered += 1;
			time_on_key=.4f;
		}else
			time_on_key += Time.deltaTime;
	}

	void OnTriggerExit2D(){
		GetComponent<SpriteRenderer> ().sprite = key_up;
		if (value.Equals ("ENTER"))
			Application.LoadLevel("Post Typing Cutscene");
		time_on_key = 0f;
		keyupsound.Play ();
	}
}
