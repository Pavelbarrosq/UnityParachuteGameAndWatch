using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject jumperPrefab;

    float lastSpawnTime;

    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float deltaRandomSpawn = 0.5f;


    public float randomSpawnDelay;

    private void Start()
    {
        if (jumperPrefab == null)
            return;

        randomSpawnDelay = spawnDelay;
        SpawnJumper();
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }


    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawn, spawnDelay + deltaRandomSpawn);
        Instantiate(jumperPrefab);
    }
}
