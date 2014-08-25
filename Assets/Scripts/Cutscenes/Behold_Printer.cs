using UnityEngine;
using System.Collections;

public class Behold_Printer : MonoBehaviour {

	private float time = 0f;
	
	// Update is called once per frame
	void Update () {
		if(time>2)
			Application.LoadLevel("Enter_Printer");
		else
			time += Time.deltaTime;
	}
}
