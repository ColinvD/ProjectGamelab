using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /**
		 * 1. Fetch JSON-formatted string from text file
		 */

        // string jsonString = "{ \"name\": \"Fabi\", \"level\": \"4711\", \"tags\": [\"Beginner\",\"Fast\"] }";
        //string jsonString = File.ReadAllText("http://22950.hosts.ma-cloud.nl/bewijzenmap/test/drawing.json");
        //Debug.Log(Application.dataPath);
        string url = "http://22950.hosts.ma-cloud.nl/bewijzenmap/test/drawing.json";
        WWW www = new WWW(url);

        /**
		 * 2. Transform JSON-formatted text into object
		 */

        /*ObjectData myObject = JsonUtility.FromJson<ObjectData>(jsonString);

        Debug.Log("Whole JSON String: " + jsonString);
        foreach (string tag in myObject.tags)
        {
            Debug.Log("Print List Item: " + tag); // logs Beginner, then Fast
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
