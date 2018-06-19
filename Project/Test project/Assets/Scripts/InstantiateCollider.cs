using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCollider : MonoBehaviour {

    [SerializeField]
    private Sprite sprite;
    private GameObject face;
    private float widthScale = 100;
    private float heightScale = 100;
    private float xScale = 20;
    private float yScale = 10;

    void Start()
    {
        face = new GameObject();
        face.name = "face";
        face.AddComponent<SpriteRenderer>();
        face.GetComponent<SpriteRenderer>().sprite = sprite;
        face.AddComponent<BoxCollider2D>();
    }

    public void UpdateTransform(int x, int y, int width, int height)
    {
        Vector3 vectemp = Camera.main.ScreenToWorldPoint(new Vector3(x, y,10));
        vectemp.x += 7;
        Debug.Log(vectemp);
        face.transform.position = new Vector3(-vectemp.x * 2.8f - 2.5f, -vectemp.y * 2 - 2, 0);
        face.transform.localScale = new Vector3(width/ widthScale, height/ heightScale, 1);
    }
}
