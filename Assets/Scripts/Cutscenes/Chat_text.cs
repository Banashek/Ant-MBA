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
											"\"wait\":1," +
											"\"say\":\"Everyone, please welcome the ant to the company.\"" +
										"}," +
										"{" +
											"\"person\":\"Illiterate Bill\"," +
											"\"wait\":3," +
											"\"say\":\"Seriously?\"" +
										"}," +
										"{" +
											"\"person\":\"Illiterate Bill\"," +
											"\"wait\":1," +
											"\"say\":\"Ugh, fine. What is his name?\"" +
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
											"\"person\":\"Ant\"," +
											"\"wait\":1," +
											"\"say\":\".......\"" +
										"}" +
										"{" +
											"\"person\":\"Illiterate Bill\"," +
											"\"wait\":1," +
											"\"say\":\"Are we done? Can we get back to business?\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":3," +
											"\"say\":\"Very well. Let’s begin our discussion of business.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":1," +
											"\"say\":\"But first, I have a project for you, ant.\"" +
										"}," +
										"{" +
											"\"person\":\"Illiterate Bill\"," +
											"\"wait\":1," +
											"\"say\":\"Give it to him good, Susan. *laugh* As if an ant could ever make it in the corporate business world.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":3," +
											"\"say\":\"That's enough, Bill.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":1," +
											"\"say\":\"Ant, I need you to go down the hall and fix the printer in Nick Knuckle's office.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":1," +
											"\"say\":\"You're the only one small enough for the job.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":1," +
											"\"say\":\"As soon as you finish, come back to me and I'll assign you another task.\"" +
										"}," +
										"{" +
											"\"person\":\"Ant\"," +
											"\"wait\":5," +
											"\"say\":\"Okay, I will. Thank you very much Susan. I'm happy to be here, and I promise not to let anyone down.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":1," +
											"\"say\":\"...Why is the ant just staring at me?\"" +
										"}," +
									"]," +
								"\"dialogue3\":" +
									"[" +
										"{" +
											"\"person\":\"Ant\"," +
											"\"wait\":1," +
											"\"say\":\"Oh no! I dropped my wedding ring in the printer!\"" +
										"}," +
										"{" +
											"\"person\":\"Ant\"," +
											"\"wait\":1," +
											"\"say\":\"My wife is going to kill me. This is not good business.\"" +
										"}," +
										"{" +
											"\"person\":\"Ant\"," +
											"\"wait\":1," +
											"\"say\":\"I've got to get that back!\"" +
										"}," +
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
