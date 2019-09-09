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
    private bool stopJumpers = false;

    private List<GameObject> jumpers = new List<GameObject>();

    private void Start()
    {
        if (jumperPrefab == null)
            return;

        randomSpawnDelay = spawnDelay;
        SpawnJumper();
    }

    private void Update()
    {
        if (!stopJumpers && Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }


    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawn, spawnDelay + deltaRandomSpawn);
        GameObject jumper = Instantiate(jumperPrefab);

        jumpers.Add(jumper);

        JumperController jumperController = jumper.GetComponentInChildren<JumperController>(); // Hjälp!

        jumperController.jumperSpawner = this;

    }

    public void Stop()
    {
        stopJumpers = true;

        for (int i = jumpers.Count - 1; i >= 0; i--)
        {
            DestroyJumper(jumpers[i]);

        }
    }

    public void DestroyJumper(GameObject jumper)
    {
        jumpers.Remove(jumper);

        Destroy(jumper);
    }
}
