using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Chat_text : MonoBehaviour {
	public JSONNode chat_node;
	public string chat_json = 
		"{" +
			"'scene':1," +
				"'chat':[" +
					"{" +
						"'person':'Susan R. Bumpershoot'," +
						"'wait':3," +
						"'say':'Everyone please welcome the ant to the business.'" +
					"}," +
					"{" +
						"'person':'Nick K. Nuckle'," +
						"'wait':3," +
						"'say':'What's his name?'" +
					"}" +
				"]" +
			"}" +
		"}";

	// Use this for initialization
	void Awake () {
		chat_node = JSON.Parse (chat_json);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
