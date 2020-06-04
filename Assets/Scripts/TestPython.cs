using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class TestPython : MonoBehaviour {
    public bool t = false;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(t) {
            t = false;
            string path = Application.dataPath + @"/playgtts.exe";
            Process p = new Process();
            p.StartInfo.WorkingDirectory = Application.dataPath;
            p.StartInfo.FileName = path;

            DateTime localDate = DateTime.Now;
            string hour = localDate.Hour.ToString();
            string minute = localDate.Minute.ToString();

            string arg = "現在時間，" + hour + "點";

            if(minute == "0") {
                arg += "整";
            }
            else {
                arg += minute + "分";
            }

            p.StartInfo.Arguments = arg;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();

            string log = p.StandardOutput.ReadToEnd();
            string errorLog = p.StandardError.ReadToEnd();

            p.WaitForExit();
            p.Close();
        }
    }
}
