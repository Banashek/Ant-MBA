using UnityEngine;
using System.Collections;

public class Ant_Name : MonoBehaviour {
	public string name;
	public int[] cutscenes = new int[3];
	public Vector3 display_location;
	public GUIStyle style;
	private Camera camera;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	void Update(){
		foreach (int scene_number in cutscenes) {
			if(Application.loadedLevel == scene_number){
				camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
				Debug.Log("Yeah butty");
				Vector3 screen_coords = camera.WorldToScreenPoint(display_location);
				Debug.Log("display_location: "+display_location);
				Debug.Log("screen_coords: "+screen_coords);
				GUI.Label(new Rect(screen_coords.x,screen_coords.y,300,1000),name,style);
			}
		}
	}
}
