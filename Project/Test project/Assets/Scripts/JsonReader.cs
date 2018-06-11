using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour {

    public class values
    {
        public int x;
        public int y;
        public int width;
        public int height;
    }

	// Use this for initialization
	IEnumerator Start () {
        string url = "http://22950.hosts.ma-cloud.nl/bewijzenmap/test/drawing.json";
        WWW www = new WWW(url);
        yield return www;
        values obj = JsonUtility.FromJson<values>(www.text);
        Debug.Log(obj.height);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
