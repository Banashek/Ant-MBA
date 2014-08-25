using UnityEngine;
using System.Collections;

public class keyboard : MonoBehaviour {

	public string name = "_";
	public GUIStyle style;
	public int keys_entered = 0;
	public float offset = 1f;
	private Vector3 display_position = new Vector3 (0, -2.6f, 0);
	private Camera camera;
	private Ant_Name name_object;


	void Awake(){
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		name_object = GameObject.FindGameObjectWithTag ("name").GetComponent<Ant_Name> ();
	}

	void OnGUI(){
		Vector3 display_screen_coords = camera.WorldToScreenPoint (display_position);
		Debug.Log ("Keys entered: " + keys_entered + "\noffset: " + offset);
		GUI.Label (new Rect(display_screen_coords.x-(offset*keys_entered),display_screen_coords.y,1000,150),name,style);
	}

	void Update(){
		if(name.Length>4){
			name_object.name = name.Substring(0,4);
		}else{
			name_object.name=name.Substring(0,name.Length-1); //accounts for the trailing '_'
		}
	}
}
