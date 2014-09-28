using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chat : MonoBehaviour
{

    const int PORT = 4444;
    Client client;
    public static List<string> message = new List<string>();
    string outMessage = "";
    string name = "";
    void Start()
    {

        Application.runInBackground = true;
        client = new Client(PORT, "127.0.0.1");
        client.Work();

    }

    void OnGUI()
    {
        GUILayout.BeginScrollView(new Vector2(0, 0), GUILayout.Width(500), GUILayout.Height(300));
        foreach (string mes in message)
        {
            GUILayout.Label(mes);
        }
        GUILayout.EndScrollView();
        name = GUILayout.TextField(name);
        outMessage = GUILayout.TextArea(outMessage, GUILayout.Width(500), GUILayout.Height(100));
        if (GUILayout.Button("Send")) client.SendMessage(name + " : " + outMessage);

    }
    void OnDestroy()
    {
        client.Destruct();
    }
}