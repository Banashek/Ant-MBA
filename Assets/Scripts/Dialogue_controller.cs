using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Dialogue_controller : MonoBehaviour {
	public int dialogue_number = 1;
	private JSONNode chat_node;
	private Chat_text chat_text;
	private float total_time = 0f;
	private bool startDialogue = true;
	// Use this for initialization
	void Start () {
		chat_text = GetComponent<Chat_text>();
		chat_node = chat_text.chat_node;
		//Debug.Log (chat_node);
		Debug.Log ("Starting dialogue");
		StartCoroutine (Dialogue (dialogue_number));
	}

	IEnumerator Dialogue(int number){
		string dialogue_number = "dialogue" + number;
		int statements_spoken=0;
		int[] times = new int[3];

		//set json to array, get number of statments for dialogue
		var dialogue = chat_node [dialogue_number].AsArray;
		int num_statements = dialogue.Count;

		//get all wait times for each statement
		for (int i=0; i<num_statements; i++) {
			times [i] = dialogue [i] ["wait"].AsInt;
		}

		//speak each statement, only after waiting appropriate wait time before each
		while (statements_spoken<num_statements) {
			//wait
			yield return new WaitForSeconds(times[statements_spoken]);
			//say statement
			string person_name = dialogue[statements_spoken]["person"];
			GameObject chat_bubble = GameObject.FindGameObjectWithTag("chat_"+person_name);
			GUIText person = chat_bubble.GetComponent<GUIText>();
			string text_to_say = person_name+": "+dialogue[statements_spoken]["say"];
			foreach(char c in text_to_say){
				person.text += c.ToString();
				//create typing effect
				yield return new WaitForSeconds(.05f);
			}
			statements_spoken+=1;
		}
		Debug.Log ("Dialogue Ended");
		startDialogue = false;
		yield return null;
	}

	// Update is called once per frame
	void Update () {
		if (!startDialogue) {
			StopCoroutine (Dialogue (dialogue_number));
		}
	}
}
