
using UnityEngine;
using System;
using System.Collections;
using SimpleJson;

public class CameraScript : MonoBehaviour
{
    public UnityEngine.GameObject[] list_of_objects;
    public const string url = "localhost:8080";
    public ArrayList positions;


    void Update()
    {
        DateTime time = DateTime.Now;

		Debug.Log ("update");


        if (time.Second % 1 == 0 && time.Millisecond < 50)
        {
            list_of_objects = GameObject.FindGameObjectsWithTag("Sending");
            positions = new ArrayList();
            Terrain terrain = GameObject.FindObjectOfType<Terrain>();
            JsonObject jsonObject = new JsonObject();

            JsonArray pointsArray = new JsonArray();

            foreach (GameObject objject in list_of_objects)
            {
                JsonObject point = new JsonObject();
                point["x"] = objject.transform.position.x;
                point["y"] = objject.transform.position.z;
                //point["scalex"] = objject.transform.localScale.x;
                //point["scaley"] = objject.transform.localScale.y;
                pointsArray.Add(point);
            }

            jsonObject["objectsArray"] = pointsArray;
            string jsonString = jsonObject.ToString();

            print(jsonString);
            Sending(jsonString, url);
        }
    }

    void Sending(string data, string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("data", data);
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            print(www.bytesDownloaded);
            GameObject quad = GameObject.FindGameObjectWithTag("ToBePainted");
            // attach texture to gameObject
            quad.renderer.material.mainTexture = www.texture;
            quad.renderer.material.shader = Shader.Find("Diffuse");
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}