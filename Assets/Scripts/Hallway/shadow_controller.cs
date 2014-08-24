using UnityEngine;
using System.Collections;

public class shadow_controller : MonoBehaviour {

	public int seconds_until_stomp = 1;
	public float seconds_of_rise = 1f;

	private float time_elapsed = 0;
	private Animator shadow_animator;
	private int phase = 0;

	void Awake(){
		shadow_animator = GetComponent<Animator> ();
	}
	void Start () {
		transform.localScale = 2 * (Vector3.right + Vector3.up);
		shadow_animator.SetBool ("stomp", true);
	}

	public void Trigger_Rise(){
		time_elapsed = 0;
		shadow_animator.SetBool ("rising", true);
		phase = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (time_elapsed > seconds_until_stomp && phase==0) {
			shadow_animator.SetBool("stomp",false);
			Trigger_Rise();
		}
		if (time_elapsed > seconds_of_rise && phase == 1) {
			shadow_animator.SetBool ("rising", false);
			Destroy(gameObject);
		}
		time_elapsed += Time.deltaTime;
	}
}
