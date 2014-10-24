using UnityEngine;
using System.Collections;

public class MarioMove : MonoBehaviour {

	public float Speed = 2;
	bool facingRight = true;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("hSpeed", Mathf.Abs (Input.GetAxis ("Horizontal"))*2);
		rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * Speed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight)
						Flip ();
				else if (move < 0 && facingRight)
						Flip ();

	}

	void Flip(){
		facingRight = ! facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
