using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField]
    private GameObject Bird;
    [SerializeField]
    private Transform[] spawnPoints;
    private float spawnTime = 1f;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnTime);
    }


    void SpawnObject()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //int BirdColorsIndex = Random.Range(0, BirdColors.Length);

        Instantiate(Bird, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}