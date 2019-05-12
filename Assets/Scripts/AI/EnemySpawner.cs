using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public AI ai;
    public GameObject[] EnemyPrefabs;
    public int SpawnTime;
    public bool Spawning;
    public int SpawnNum = 5;

    public GameObject Prefab;

    public void Awake()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update ()
    {
        if (SpawnNum >= 1)
        {
            StartCoroutine(SpawnEnemies());
        }
	}

    IEnumerator SpawnEnemies()
    {
        if (Spawning == false)
        {
            Spawning = true;
            Vector3 spawn = transform.position + new Vector3(0, 5, 0);
            Instantiate(Prefab, spawn, transform.rotation);
            SpawnNum -= 1;
            yield return new WaitForSeconds(SpawnTime);
            Spawning = false;
        }
    }
}
