
using UnityEngine;
using System;
using System.Collections;
using SimpleJson;

public class ClockAnimator : MonoBehaviour
{
    public UnityEngine.GameObject[] list_of_objects;
    public UnityEngine.GameObject terrain;
    public Transform hours, minutes, seconds;
    public bool analog;
    public const string url = "localhost:8080";
    public ArrayList positions;
    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;
    void Update()
    {
        DateTime time = DateTime.Now;

        hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
        minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
        seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);


        if (time.Second % 5 == 0)
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
                point["y"] = objject.transform.position.y;
                //point["scalex"] = objject.transform.localScale.x;
                //point["scaley"] = objject.transform.localScale.y;
                pointsArray.Add(point);

            }
            JsonObject jsterrain = new JsonObject();
            jsterrain["x"] = terrain.transform.position.x;
            jsterrain["y"] = terrain.transform.position.y;
            jsterrain["width"] = terrain.terrainData.size.x;
            jsterrain["height"] = terrain.terrainData.size.y;
            pointsArray.Add(jsterrain);
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
            quad.renderer.material.shader = Shader.Find("Transparent/Diffuse");
            Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}