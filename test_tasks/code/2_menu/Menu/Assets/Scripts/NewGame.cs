using UnityEngine;
using System.Collections;

public class NewGame: MonoBehaviour {
 	void OnMouseEnter(){
		renderer.material.color = Color.red;
	}
	void OnMouseExit(){
		renderer.material.color = Color.white;
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameObject.Find("txtNewGame").renderer.enabled = true;		
		}
		else if (Input.GetKeyDown (KeyCode.Space)){
			GameObject.Find("txtNewGame").renderer.enabled = false;	
		}
	}
}
