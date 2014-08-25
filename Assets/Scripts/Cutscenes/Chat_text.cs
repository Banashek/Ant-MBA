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
									"]," +
								"\"dialogue4\":" +
									"[" +
										"{" +
											"\"person\":\"Illiterate Bill\"," +
											"\"wait\":0," +
											"\"say\":\"Where the hell is that ant?!\"" +
										"}" +
									"]," +
								"\"dialogue5\":" +
									"[" +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":1," +
											"\"say\":\"Ah, there you are.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":0," +
											"\"say\":\"I’m very impressed with your work, Ant. You’ve gone above and beyond in your duties, and it shows.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":0," +
											"\"say\":\"Keep up this hustle and one day you will find your way to the tip top of this company.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":0," +
											"\"say\":\"You can be the long-awaited proof that ants and people can work together to create harmonious business synergy.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":0," +
											"\"say\":\"Think about it, ant.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":0," +
											"\"say\":\"Once people finally accept you and your kind into our businesses, you’ll find that you’re mere steps away from being accepted into our hearts.\"" +
										"}," +
										"{" +
											"\"person\":\"Susan R. Bumpershoot\"," +
											"\"wait\":0," +
											"\"say\":\"I believe in you.\"" +
										"}" +

									"]," +
								"\"dialogue6\":" +
									"[" +
										"{" +
										"\"person\":\"Illiterate Bill\"," +
										"\"wait\":1," +
										"\"say\":\"Dude, the printer's still totally broken.\"" +
										"}" +
									"]" +
								"}";
	

	// Use this for initialization
	void Awake () {
		chat_node = JSON.Parse (chat_json);
	}

}
