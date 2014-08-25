using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Dialogue_controller : MonoBehaviour {

	public int dialogue_number = 1;
	public string character_name;
	public GUIStyle style;
	private Chat_text chat_text;
	private JSONNode chat_node;
	private float total_time = 0f;
	private bool startDialogue = true;
	private SpriteRenderer r;
	private bool nextLetter;
	private Rect text_rect;
	private string person_name,string_to_display;

	IEnumerator Dialogue(int number){
		string dialogue_number = "dialogue" + number;
		int statements_spoken=0;
		int[] times = new int[15];
		
		//set json to array
		var dialogue = chat_node [dialogue_number].AsArray;
		
		//get all wait times for each statement
		for (int i=0; i<dialogue.Count; i++) {
			times [i] = dialogue [i] ["wait"].AsInt;
		}
		Debug.Log ("dialogue.count = " + dialogue.Count);
		//speak each statement, only after waiting appropriate wait time before each
		while (statements_spoken<dialogue.Count) {
			string json_char_name = (string)dialogue[statements_spoken]["person"];
			string text_to_say = dialogue[statements_spoken]["say"];
			if(!json_char_name.Equals(character_name)){
				yield return new WaitForSeconds(times[statements_spoken]+(.05f*(json_char_name.Length+2)+.1f*(text_to_say.Length-1)));
				statements_spoken+=1;
				continue;
			}
			Debug.Log("Speaking statement: "+statements_spoken);
			//wait
			yield return new WaitForSeconds(times[statements_spoken]);
			//say statement
			person_name = dialogue[statements_spoken]["person"]+":\n";
			nextLetter=true;
			string_to_display = person_name;
			//type statement
			foreach(char c in text_to_say){
				string_to_display += c;
				if(string_to_display.Length>120){
					Wrap_Text();
				}
				//create typing effect
				yield return new WaitForSeconds(.1f);
			}
			statements_spoken+=1;
			yield return new WaitForSeconds(1f);
			nextLetter = false;
		}
		Debug.Log ("Dialogue Ended");
		startDialogue = false;
		yield return null;
	}

	void Wrap_Text(){
		int last_space = string_to_display.LastIndexOf(" ");
		Debug.Log ("last index of space: "+last_space);
		Debug.Log ("length-1: "+(string_to_display.Length-1)+"\nCharacter at length-1: "+string_to_display[string_to_display.Length-1]);
		Debug.Log("substring from last_space to end: "+string_to_display.Substring(last_space,string_to_display.Length-last_space));
		string last_word = string_to_display.Substring(last_space,string_to_display.Length-last_space);
		string_to_display = person_name+last_word;
	}

	void Awake(){
		chat_text = GetComponent<Chat_text>();
		r = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		//get json data
		//chat_text = GetComponent<Chat_text>();
		chat_node = chat_text.chat_node;
		//Debug.Log ("chat_node: " + chat_node);
		//set text location within chat bubble
		Camera camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		Vector3 mod_pos = transform.position;
		mod_pos.y *= -1;
		Vector3 top_left_bubble_pos_world = mod_pos - new Vector3 (1.8f,.75f, 0f);
		Vector3 text_position = camera.WorldToScreenPoint (top_left_bubble_pos_world);
		text_rect = new Rect (text_position.x, text_position.y, 300,1000);
		//start dialogue
		r.enabled = false;
		Debug.Log ("Starting dialogue");
		StartCoroutine (Dialogue (dialogue_number));
	}

	void OnGUI(){
		GUI.color = Color.black;

		//21 characters per line only
		if(nextLetter){
			r.enabled = true;
			GUI.Label (text_rect, string_to_display,style);
		}else
			r.enabled=false;
	}
	
	void Update () {
		if (!startDialogue) {
			StopCoroutine (Dialogue (dialogue_number));
			Destroy(gameObject);
		}
	}
}
