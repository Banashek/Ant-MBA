using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * using m=2.5/30 as slope for upper bound on spawn time
 * time between spawn = [0,-m*distance_travelled+3]
 */ 

public class Foot_Stomp_Controller : MonoBehaviour {

	public GameObject foot_shadow, foot;
	public float seconds_before_the_pounding = 2f;
	private static float slope = 2.5f / 60f;
	private Transform ant;
	private float timer=0f;
	private float wait_time =.5f;
	private float distance_travelled = 0f;
	private Vector3 last_stomp_location,start_location;
	private bool stompings_begun = false;


	void Start () {
		ant = GameObject.FindGameObjectWithTag ("Player").transform;
		start_location = ant.position;
		last_stomp_location = ant.position;
	}

	IEnumerator Instantiate_Foot(Vector3 location){
		yield return new WaitForSeconds (1);
		Instantiate (foot, location, Quaternion.identity);
		yield return null;
	}

	void Update () {
		if(stompings_begun){
			if (timer > wait_time) {
				//stomp
				Vector3 stomp_location = ant.position + new Vector3(Random.Range(0f,2f),Random.Range(-.5f,.25f),0);
				if(Vector3.Distance(stomp_location,last_stomp_location)<.5f)
					stomp_location = ant.position + new Vector3(Random.Range(0f,2f),Random.Range(-.5f,0),0);
				last_stomp_location = stomp_location;
				Instantiate(foot_shadow,stomp_location,Quaternion.identity);
				StartCoroutine(Instantiate_Foot(stomp_location+(2*Vector3.up)));
				//Instantiate(foot,stomp_location+(2*Vector3.up),Quaternion.identity);
				//reset timer
				float distance_travelled = Vector3.Distance(ant.position,start_location);
				if(distance_travelled>60){
					stompings_begun=false;
					seconds_before_the_pounding = 1000;
				}
				float longest_wait_time = 3 - (slope*distance_travelled);
				wait_time = Random.Range (0f, longest_wait_time);
				timer = 0f;
			}
		}else if(timer>seconds_before_the_pounding){
			timer=0f;
			stompings_begun=true;
		}
		timer += Time.deltaTime;
	}
}
