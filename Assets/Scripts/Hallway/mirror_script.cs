using UnityEngine;
using System.Collections;

public class mirror_script : MonoBehaviour {

	public bool isMirrored = false;

	private GameObject level;

	void FlipGameObject(GameObject o){
		Vector3 scale = o.transform.localScale;
		scale.x *= -1;
		o.transform.localScale = scale;
	}

	void Start(){
		if(isMirrored){
			FlipGameObject(GameObject.FindGameObjectWithTag("level"));
		}
	}
}
