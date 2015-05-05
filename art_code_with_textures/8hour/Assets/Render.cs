using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
//using System.Windows.UIElement;

// ReSharper disable once UnusedMember.Global
public class Render : MonoBehaviour {
    private int _length;
    private ProceduralMaterial _substance;
    public bool doWindow0;
    public Material[] Materials;
    public Renderer Rend;
    public Vector2 Scrolling;
    public Vector2 ScrollPosition = Vector2.zero;
    public Rect SliderRect = new Rect(5, 5, 100, 30);
    public float SliderValue;
    public Rect WindowRect0 = new Rect(20, 20, 120, 50);
    public Rect WindowRect1 = new Rect(20, 100, 120, 50);
    public GameObject Sphere;


    private void Awake() {
        // Materials = (ProceduralMaterial[])Resources.FindObjectsOfTypeAll(typeof(ProceduralMaterial));
        Materials = Resources.FindObjectsOfTypeAll(typeof (ProceduralMaterial)) as Material[];
        GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Bumped Diffuse");
        //Materials = (ProceduralMaterial[])Resources.FindObjectsOfTypeAll(typeof(ProceduralMaterial));
        if (Materials == null) {
            Debug.Log("Materials is null");
        }
        Sphere = GameObject.Find("Sphere");
        if (Sphere == null) {
            throw new ArgumentNullException("Sp" + "here");
        }
    }

    private void Start() {
        Debug.Log("I am alive!");
        Rend = GetComponent<Renderer>();

        Debug.Log(Materials.Length + " materials");
        
        doWindow0 = true;
 
        
        var buttonPrefab = Resources.FindObjectsOfTypeAll<Button>().First();
        Debug.Log(string.Format("buttons {0} ff", buttonPrefab));
        
        var canvas = FindObjectOfType<Canvas>();
        var length = Materials.Length;
        int i = 0;
        var materialButtons = Materials.Select(m => {
            i++;
            var result = Instantiate(buttonPrefab);
            result.transform.SetParent(GameObject.FindGameObjectWithTag("SView").transform);
            result.transform.localPosition = new Vector3(0, (-10.0f) * i - 10.0f);
            // Потому что прототип и не должен быть виден в сцене.
            // В канвасе его копии. Похрен, где оригинал.


            // Расставить кнопочки не в одну точку, а по порядку.
            result.enabled = true;
            result.gameObject.SetActive(true);
            var text = result.targetGraphic.GetComponentsInChildren<Text>();
            if (text == null ||
                text.FirstOrDefault() == null) {
                Debug.Log("aaaa");
            } else {
                text.First().text = m.name;
            }
            // Добавим в скролл рект
            
            //расставляй кнопки=)
            result.onClick.AddListener(() => {
                Sphere.GetComponent<Renderer>().material = m;
                var SVL = GameObject.Find("L_ScrollView");
                var pm = m as ProceduralMaterial;
                var inputs = pm.GetProceduralPropertyDescriptions();
                foreach (var v in inputs) {
                    Debug.Log(v.name);
                    if (v.type == ProceduralPropertyType.Float) {
                        var ans = Instantiate(GameObject.Find("S_Slider"));
                        ans.transform.SetParent(GameObject.FindGameObjectWithTag("SView2").transform);
                        ans.transform.localPosition = new Vector3(0, 20);
                    }
                }

            });
            // Это перфекционизм или просто скучно было?

            return result;
        }).ToList();

    }

    private void OnGUI() {
        //GUI.HorizontalSlider(new Rect(5, 5, 100, 30), 0, -100, 100);
        //GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        //GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        //GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        //GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");

        //GUI.Window(0, new Rect (50, 50, 200, 200), doMyWindow, "wind");
        //windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "My Window");
        //windowRect1 = GUI.Window(1, windowRect1, DoMyWindow, "My Window");
        //GUI.Window (0, new Rect(0,0,300,300), ProceduralPropertiesGUI, "Procedural Properties");

        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button")) {
            print("You clicked the button!");

            _substance = GetComponent<Renderer>().material as ProceduralMaterial;

            //  ScrollPosition = GUI.BeginScrollView(new Rect(100, 300, 100, 100), ScrollPosition, new Rect(0, 0, 220, 200));

            if (_substance != null) {
                _substance.GetProceduralPropertyDescriptions();
                //Rect windowRect = new Rect (Screen.width - 250, 30, 220, Screen.height - 60);
                var inputs = _substance.GetProceduralPropertyDescriptions();
                // try to change properties;

                foreach (var t in inputs) {
                    Debug.Log(t.type + " " + t.name + " from " + t.minimum + " to " + t.maximum);
                    if (t.type == ProceduralPropertyType.Float) {
                        SliderValue = GUI.HorizontalSlider(SliderRect, 0.0F, -100, 100);
                    }
                }

                _substance.RebuildTextures();

                // попробуй намутить с нормалмапом
                var bufferTexture = new Texture2D(_substance.mainTexture.width,
                    _substance.mainTexture.height,
                    TextureFormat.RGB24,
                    false);
                _substance.isReadable = true;
                _substance.RebuildTexturesImmediately();

                var proceduralTextures = _substance.GetGeneratedTextures();

                var counter = 0;
                foreach (var texture in proceduralTextures) {
                    var proceduralTexture = texture as ProceduralTexture;
                    if (proceduralTexture != null) {
                        bufferTexture.SetPixels32(
                            proceduralTexture.GetPixels32(0, 0, texture.width, texture.height),
                            0);
                        var bytes = bufferTexture.EncodeToPNG();
                        var fileName = string.Format("{0}{1}_imageppp.png", Application.dataPath, counter);
                        File.WriteAllBytes(fileName, bytes);
                    } else {
                        Debug.LogError(string.Format("not a ProceduralTexture! #{0}", counter));
                    }

                    counter++;
                }
            } else {
                Debug.LogError("There is no Procedural Material", gameObject);
            }
        }
    }

    private void DoWindow0(int windowId) {
        GUI.Button(new Rect(10, 30, 80, 20), "Click Me!");
    }

    private void DoMyWindow(int windowId) {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World")) {
            print("Got a click in window " + windowId);
        }

        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }
}