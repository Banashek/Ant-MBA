using UnityEngine;
using System.Collections;

public class SideScrollerController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask isGround;
	public float jumpForce = 500f;
	public int playerNumber = 1;
	public string playerInputName;
	public Vector3 playerResetPoint;
	public int jumpButton; 
	
	void Awake(){
	}
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, isGround);
		float move = Input.GetAxis ("Horizontal");
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
	}
	
	void Update() {
		
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
	
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet" || coll.gameObject.tag == "Saw")
			Dead ();
	}
	
	void Dead(){
		gameObject.transform.position = playerResetPoint;
		//Application.LoadLevel (0);
	}
}