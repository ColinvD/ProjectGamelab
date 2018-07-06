using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JsonReader : MonoBehaviour {

    [SerializeField]
    private float waitSeconds = 0f;
    /*[SerializeField]
    private Text text;
    private int count;*/

    public class values
    {
        public int x;
        public int y;
        public int width;
        public int height;
    }

    private values FaceValues;

	// Use this for initialization
	void Start () {
        StartCoroutine(PollData());
    }

    IEnumerator PollData()
    {
        string url = "http://22950.hosts.ma-cloud.nl/bewijzenmap/test/drawing.json";
        WWW www = new WWW(url);
        //yield return www;
        //values obj = JsonUtility.FromJson<values>(www.text);
      //  Debug.Log("x: " + obj.x + ", y: " + obj.y + ", width: " + obj.width + ", height: " + obj.height);
        while (!www.isDone)
        {
           // values obj = JsonUtility.FromJson<values>(www.text);
           // Debug.Log("x: " + obj.x + ", y: " + obj.y + ", width: " + obj.width + ", height: " + obj.height);
            yield return null;
        }

        //count++;
        //text.text = "" + count;
        FaceValues = JsonUtility.FromJson<values>(www.text);
        FindObjectOfType<InstantiateCollider>().UpdateTransform(FaceValues.x, FaceValues.y, FaceValues.width, FaceValues.height);
        Debug.Log("x: " + FaceValues.x + ", y: " + FaceValues.y + ", width: " + FaceValues.width + ", height: " + FaceValues.height);

        yield return new WaitForSeconds(waitSeconds);
        StopAllCoroutines();
        StartCoroutine(PollData());
    }
}
