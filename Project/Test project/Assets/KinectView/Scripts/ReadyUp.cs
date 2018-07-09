using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyUp : MonoBehaviour {

	void Start () {
        //Time.timeScale = 0.0f;
	}
	

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ReadyUp")
        {
            print("asdasd");
            Time.timeScale = 1.0f;                      
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Application.LoadLevel(1);
    }
}
