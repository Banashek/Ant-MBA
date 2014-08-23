using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Chat_text : MonoBehaviour {
	public JSONNode chat_node;
	public string chat_json = "{" +
								"\"dialogue1\":" +
									"[" +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":3," +
											"\"say\":\"Everyone, please welcome the ant to the company.\"" +
										"}," +
										"{" +
											"\"person\":\"Nick K. Nuckle\"," +
											"\"wait\":3," +
											"\"say\":\"What is his name?\"" +
										"}" +
									"]," +
								"\"dialogue2\":" +
									"[" +
										"{" +
											"\"person\":\"Illiterate Bill\"," +
											"\"wait\":3," +
											"\"say\":\"What did he type?\"" +
										"}," +
										"{" +
											"\"person\":\"You\"," +
											"\"wait\":1," +
											"\"say\":\".......\"" +
									"]" +
								"}";
	
	// Use this for initialization
	void Awake () {
		chat_node = JSON.Parse (chat_json);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
