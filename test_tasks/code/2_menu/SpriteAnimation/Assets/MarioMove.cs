using UnityEngine;
using System.Collections;

public class MarioMove : MonoBehaviour {

	public float Speed = 2;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (Input.GetAxis ("Horizontal") * Speed, 0);
		anim.SetFloat ("hSpeed", Mathf.Abs (rigidbody2D.velocity.x));

//		if (rigidbody2D.velocity.x < 0 && transform.localScale.x >)
	}
}
