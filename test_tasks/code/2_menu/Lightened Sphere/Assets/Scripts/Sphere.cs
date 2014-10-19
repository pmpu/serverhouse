using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {
	void OnMouseEnter(){
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = true;
	}
	void OnMouseExit(){
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}

	// Use this for initialization
	void Start () {
		Behaviour h = (Behaviour)GetComponent("Halo");
		h.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
