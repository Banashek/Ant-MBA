using UnityEngine;
using System.Collections;

public class Enter_Printer : MonoBehaviour {
	private GameObject[] dialog;
	private GameObject ant;
	private bool enter=false;
	private float distance, distance_to_travel = 1.07f;
	// Use this for initialization
	void Awake(){
		ant = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () {
		if(!enter){
			dialog = GameObject.FindGameObjectsWithTag ("dialogue");
			if(dialog.Length==0){
				Debug.Log("Dialogue over");
				enter = true;
				distance = 0f;
			}
		}

		if(enter){
			if(distance<distance_to_travel){
				Vector3 trans_vect = Vector3.up*Time.deltaTime;
				ant.transform.Translate(trans_vect);
				distance += Vector3.Magnitude(trans_vect);
				Debug.Log(distance);
			}else{
				Application.LoadLevel("Printer");
			}
		}
	}
}
