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

    private Vector3 pvec;
    private Vector3 tvec;
    private float time;

    void Start()
    {
        face = new GameObject();
        face.name = "face";
        face.AddComponent<SpriteRenderer>();
        face.GetComponent<SpriteRenderer>().sprite = sprite;
        face.AddComponent<BoxCollider2D>();
    }

    void Update()
    {
        face.transform.position = Vector3.Lerp(pvec, tvec, time);
    }

    public void UpdateTransform(int x, int y, int width, int height)
    {
        /*Vector3 vectemp = Camera.main.ScreenToWorldPoint(new Vector3(x, y,10));
        vectemp.x += 7;
        //Debug.Log(vectemp);
        face.transform.position = new Vector3(-vectemp.x * 2.8f - 2.5f, -vectemp.y * 2 - 2, 0);
        face.transform.localScale = new Vector3(width/ widthScale, height/ heightScale, 1);*/
        pvec = face.transform.position;
        Vector3 vectemp = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 10));
        vectemp.x += 7;
        //Debug.Log(vectemp);
        tvec = new Vector3(-vectemp.x * 2.8f - 2.5f, -vectemp.y * 2 - 2, 0);
        StopCoroutine(move());
        StartCoroutine(move());
        face.transform.localScale = new Vector3(width / widthScale, height / heightScale, 1);
    }

    private IEnumerator move()
    {
        time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
