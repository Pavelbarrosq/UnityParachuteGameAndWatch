using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject jumperPrefab;

    float lastSpawnTime;

    GameManager gameManager;

    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float deltaRandomSpawn = 0.5f;

    public float decreaseSpawnDelay = 0.01f;


    public float randomSpawnDelay;
    private bool stopJumpers = false;

    private List<GameObject> jumpers = new List<GameObject>();

    private void Start()
    {
        if (jumperPrefab == null)
            return;

        gameManager = GetComponent<GameManager>();

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
        float delay = Mathf.Clamp( spawnDelay - (decreaseSpawnDelay * gameManager.Points()), deltaRandomSpawn, spawnDelay);
        randomSpawnDelay = Random.Range(delay - deltaRandomSpawn, delay + deltaRandomSpawn);
        GameObject jumper = Instantiate(jumperPrefab);

        jumpers.Add(jumper);

        JumperController jumperController = jumper.GetComponentInChildren<JumperController>(); // Hjälp!

        jumperController.jumperSpawner = this; // hjälp!

    }

    public void DestroyJumper(GameObject jumper)
    {
        jumpers.Remove(jumper);

        Destroy(jumper);
    }

    public void Stop()
    {
        stopJumpers = true;

        for (int i = jumpers.Count - 1; i >= 0; i--)
        {
            DestroyJumper(jumpers[i]);

        }
    }

    
}
