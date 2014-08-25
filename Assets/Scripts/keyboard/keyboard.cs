using UnityEngine;
using System.Collections;

public class keyboard : MonoBehaviour {

	public string name = "_";
	public GUIStyle style;
	public int keys_entered = 0;
	public float offset = 1f;
	private Vector3 display_position = new Vector3 (0, -2.6f, 0);
	private Camera camera;


	void Awake(){
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
	}

	void OnGUI(){
		Vector3 display_screen_coords = camera.WorldToScreenPoint (display_position);
		Debug.Log ("Keys entered: " + keys_entered + "\noffset: " + offset);
		GUI.Label (new Rect(display_screen_coords.x-(offset*keys_entered),display_screen_coords.y,1000,150),name,style);
	}
}
