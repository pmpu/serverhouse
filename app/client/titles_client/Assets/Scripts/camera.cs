using UnityEngine;
using System.Collections;
using SimpleJson;
using System.IO;
using UnityEngine.UI;




public class camera : MonoBehaviour {
	private JsonArray titles_array = null;
	private bool guiStarted = false;

	// Use this for initialization
	IEnumerator Start () {
		if (titles_array == null) {
			
			WWW www = new WWW("localhost:8080/api.aspx?getTitles=true");
			yield return www;		
			if (www.error == null){
				Debug.Log("WWW Ok!: " + www.text);
				JsonArray titlesArray = (JsonArray) SimpleJson.SimpleJson.DeserializeObject(www.text);

				if(titlesArray.Count == 0)
					return false;

				GameObject textObj = GameObject.Find ("Text");
				Vector3 init_position = textObj.transform.position;
				int title_number = 0;
				while(true){
					JsonObject t = (JsonObject)titlesArray[title_number];
					string text = t["position"]+"\n"+t["first_name"]+" "+t["last_name"];
					
					yield return new WaitForSeconds(3);
					
					textObj.GetComponent<Text>().text = text;
					Vector3 position = textObj.transform.position;
					position.x = -500;
					position.y = init_position.y;
					textObj.transform.position = position;
					LeanTween.moveX(textObj, init_position.x, .4f).setEase(LeanTweenType.easeOutElastic);
					LeanTween.moveX(textObj, init_position.x*3, .3f).setDelay(2.5f).setEase(LeanTweenType.easeOutElastic);
					
					title_number++;
					if(title_number == titlesArray.Count){
						title_number = 0;
					}
				}
				
			}else{
				Debug.Log("WWW Error: " + www.error);
			}
			
		}
	}

	void OnGUI(){
		guiStarted = true;
	}


	// Update is called once per frame
	void Update () {

	}
}
