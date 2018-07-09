using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandStart : MonoBehaviour
{

    [SerializeField]
    private Slider Hold;
    private float _maxHealth = 0;
    private float _currentlives;

    void Start()
    {
        Hold = GameObject.Find("Slider").GetComponent<Slider>();
        _currentlives = _maxHealth;
    }

    private void Update()
    {
        StartGame();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Start")
        {
            //_currentlives += 5;
            //Hold.value = _currentlives;
            //print(_currentlives);
            Application.LoadLevel(1);
        }
    }

    public void StartGame()
    {
        if (_currentlives >= 100)
        {
            Application.LoadLevel(1);
            print("yis");
        }
    }
}
