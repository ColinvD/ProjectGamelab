using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bubble")
        {
            collision.gameObject.SetActive(false);
            Score.score += 1;
        }
 }
}
