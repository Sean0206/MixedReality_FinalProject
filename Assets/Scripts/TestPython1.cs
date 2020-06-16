using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using IronPython.Hosting;

public class TestPython1 : MonoBehaviour {
    public bool t = false;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(t) {
            t = false;
            var engine = Python.CreateEngine();
            ICollection<string> searchPaths = engine.GetSearchPaths();

            searchPaths.Add(Application.dataPath);
            searchPaths.Add(Application.dataPath + @"/Plugins/Lib/");
            engine.SetSearchPaths(searchPaths);

            dynamic py = engine.ExecuteFile(Application.dataPath + @"/playgtts.py");
            dynamic speak = py.Speak();
            speak.doSpeak("測試測試測試");
            UnityEngine.Debug.Log("Done");
        }
    }

    public void Detect() {
        t = true;
    }
}
