using UnityEngine;
using System.Collections;
//using UnityEngine.Windows;
using System.IO;

public class Render : MonoBehaviour {

	// Use this for initialization
	void Start () {

		renderer.material.shader = Shader.Find("Transparent/Diffuse");
		Texture2D texture = new Texture2D(128, 128, TextureFormat.ARGB32, false);
		renderer.material.mainTexture = texture;
		ProceduralMaterial substance;
		substance = renderer.material as ProceduralMaterial;
		//substance.GetGeneratedTextures ();

		//var textures = substance.GetGeneratedTextures ();
		var textures = substance.GetGeneratedTextures ();
		substance.isReadable = true;
		substance.RebuildTexturesImmediately ();

		//Texture2D textures2 = textures.Clone() as Texture2D;
		//Color[] pix = textures.GetPixels32 ();
		int k = 0;
		Texture2D[] tt = textures.Clone() as Texture2D[];
		Texture2D[] tmptexture;
		//Texture2D[] tmptexture = new Texture2D(128, 128, TextureFormat.ARGB32, false);
		foreach(var t in tt) {
			t.GetPixels32 ();
			texture.SetPixels32(t.GetPixels32 (), 0);
			var bytes = texture.EncodeToPNG();
			File.WriteAllBytes(Application.dataPath+"imageppp.png", bytes);
			k++;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
