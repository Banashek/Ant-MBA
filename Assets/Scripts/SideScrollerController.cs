using UnityEngine;
using System.Collections;

public class SideScrollerController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;
	Animator anim;
	
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask isGround;
	public float jumpForce = 500f;
	public int playerNumber = 1;
	public string playerInputName;
	Vector3 playerResetPoint;
	public int jumpButton; 
	
	void Awake()
	{
	}
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, isGround);
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight) 
				Flip ();
		else if (move < 0 && facingRight)
				Flip ();
			
	}
	
	void Update() 
	{	
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.layer == 13) {
			Debug.Log("Player touched checkpoint");
			playerResetPoint = coll.transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.layer == 12) {
			Dead ();
		}
	}
	
	void Dead()
	{
		gameObject.transform.position = playerResetPoint;
		//Application.LoadLevel (0);
	}
}