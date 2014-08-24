using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Foot_Stomp_Controller : MonoBehaviour {

	public GameObject foot_shadow;
	public float seconds_before_the_pounding = 2f;
	private Transform ant;
	private float timer=0f;
	private float wait_time =.5f;
	private Vector3 last_stomp_location;
	private bool stompings_begun = false;

	void Start () {
		ant = GameObject.FindGameObjectWithTag ("Player").transform;
		last_stomp_location = ant.position;
	}

	void Update () {
		if(stompings_begun){
			if (timer > wait_time) {
				//stomp
				Vector3 stomp_location = ant.position + new Vector3(Random.Range(0f,2f),Random.Range(-1f,0),0);
				if(Vector3.Distance(stomp_location,last_stomp_location)<.5f)
					stomp_location = ant.position + new Vector3(Random.Range(0f,2f),Random.Range(-1f,0),0);
				last_stomp_location = stomp_location;
				Instantiate(foot_shadow,stomp_location,Quaternion.identity);
				//reset timer
				wait_time = Random.Range (.5f, 2f);
				timer = 0f;
			}
		}else if(timer>seconds_before_the_pounding){
			timer=0f;
			stompings_begun=true;
		}
		timer += Time.deltaTime;
	}
}
