using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	private float stoneVal = 0.0f;

	public void changeStoneVal (float newStoneVal){
		stoneVal = newStoneVal;
	}

	void Update () {
		ProceduralMaterial substance = renderer.sharedMaterial as ProceduralMaterial;
		if (substance){
			substance.SetProceduralFloat("Stone_Type", stoneVal);
			substance.RebuildTextures();
		}
	}

	void Start () {
		
	}
}