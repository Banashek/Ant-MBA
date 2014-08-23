using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Dialogue_controller : MonoBehaviour {
	private JSONNode chat_node;
	private float total_time = 0f;
	// Use this for initialization
	void Start () {
		chat_node = GameObject.FindGameObjectWithTag ("json").GetComponent<Chat_text>().chat_node;

	}
	
	// Update is called once per frame
	void Update () {
		if (total_time > 1) {
			Debug.Log (chat_node[0][0]);
			total_time = -10;
		} else if (total_time >= 0) {
			total_time += Time.deltaTime;
		}
	}
}
