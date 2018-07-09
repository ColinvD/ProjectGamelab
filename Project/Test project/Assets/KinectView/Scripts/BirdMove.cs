using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer mySpriteRenderer;

    private float directionSpeedVertical;
    private float directionSpeedHorizontal;
    private float spawnLeftOrRight;

    void Awake()
    {
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        directionSpeedVertical = Random.Range(1, 10);
        directionSpeedHorizontal = Random.Range(1, 10);
        spawnLeftOrRight = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * directionSpeedVertical);

        if (spawnLeftOrRight < .5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * directionSpeedHorizontal);
            Rotate();
        }
        else if (spawnLeftOrRight < 1f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * directionSpeedHorizontal);
        }
    }

    void Rotate()
    {
        float tempX = transform.position.x;
        mySpriteRenderer.flipX = true;
        transform.position = new Vector3(tempX, transform.position.y, transform.position.z);
    }
}