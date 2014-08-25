using UnityEngine;
using System.Collections;

public class Ant_Name : MonoBehaviour {
	public string name;
	public int[] cutscenes = new int[3];
	public Vector3 display_location,screen_coords;
	public GUIStyle style;
	private Camera camera;
	private bool show_name;
	private int in_proper_scene = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	void Update(){
		in_proper_scene = 0;
		foreach (int scene_number in cutscenes) {
			if(Application.loadedLevel == scene_number){
				in_proper_scene +=1;
				camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
				Debug.Log("Yeah butty");
				screen_coords = camera.WorldToScreenPoint(display_location);
				show_name=true;
			}
		}
		if (in_proper_scene == 0){
			show_name = false;
		}
	}

	void OnGUI(){
		if(show_name){
			GUI.Label(new Rect(screen_coords.x,screen_coords.y,300,1000),name,style);
			Debug.Log ("Showing name");
		}
	}
}
