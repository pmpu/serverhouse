using System.IO;
using UnityEngine;

// ReSharper disable once UnusedMember.Global
public class Render : MonoBehaviour {

	void Start () {
		GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
	    var substance = GetComponent<Renderer>().material as ProceduralMaterial;

	    if (substance != null) {
	        var bufferTexture = new Texture2D( substance.mainTexture.width, substance.mainTexture.height, TextureFormat.RGBA32, false );
	        substance.isReadable = true;
            substance.RebuildTexturesImmediately();

            var proceduralTextures = substance.GetGeneratedTextures();

            var counter = 0;
	        foreach(var texture in proceduralTextures) {
	        
                var proceduralTexture = texture as ProceduralTexture;
                if (proceduralTexture != null) {
	                bufferTexture.SetPixels32(proceduralTexture.GetPixels32(0, 0, texture.width, texture.height), 0);
                    var bytes = bufferTexture.EncodeToPNG();
                    var fileName = string.Format( "{0}{1}_imageppp.png", Application.dataPath, counter );
                    File.WriteAllBytes( fileName, bytes );
	            }
	            else {
                    Debug.LogError( string.Format("not a ProceduralTexture! #{0}", counter) );
	            }

                counter++;
	        }
        } else {
            Debug.LogError( "There is no Procedural Material", gameObject );
        }
	}
}
