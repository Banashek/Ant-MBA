using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cutscene_Controller : MonoBehaviour {
	public int scene;
	// Update is called once per frame
	void Update () {
		GameObject[] dialogues = GameObject.FindGameObjectsWithTag("dialogue");
		if(dialogues.Length==0){
			//transition
			Debug.Log ("Load next scene");
			if (scene==0)
				Application.LoadLevel("Typing");
			else if (scene==1)
				Application.LoadLevel("hallway");
		}
	}
}
