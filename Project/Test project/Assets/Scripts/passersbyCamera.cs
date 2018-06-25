using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passersbyCamera : MonoBehaviour {

    private WebCamTexture tex;
    public RawImage display;

	// Use this for initialization
	void Start () {
        WebCamDevice device = WebCamTexture.devices[0];
        tex = new WebCamTexture(device.name);
        display.texture = tex;
        tex.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
