using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject spawn;

    public float spawnTime;
    public float spawnCounter;
    public GameObject spawnTransform;
    public DayNightCycle dayNight;


    private void Start()
    {
        spawnCounter = spawnTime;
        
    }

    private void Update()
    {
        spawnCounter = spawnCounter -1 * Time.deltaTime;
        int randomSpawn = Random.Range(0, 3);
        if (spawnCounter <= 0 && dayNight.dayOver == false)
        {
            Instantiate(enemyList[randomSpawn], spawn.transform.position, Quaternion.identity, spawnTransform.transform);
            spawnCounter = spawnTime;
        }
    }
}
