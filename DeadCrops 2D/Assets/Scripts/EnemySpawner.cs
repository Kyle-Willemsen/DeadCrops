using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject spawnParent;

    public float spawnTime;
    public float spawnCounter;
    public float minSpawntime;
    public float maxSpawnTime;
    public DayNightCycle dayNight;
    public bool canSpawn;

    public int enemyTypeCounter;
    public float enemyCounter;


    private void Start()
    {
        spawnCounter = spawnTime;
        canSpawn = true;
    }

    private void Update()
    {
        if (spawnCounter == spawnTime)
        {
            spawnTime = Random.Range(minSpawntime, maxSpawnTime);
        }
        

        spawnCounter = spawnCounter -1 * Time.deltaTime;
        int randomEnemy = Random.Range(0, enemyTypeCounter);
        int randomSpawn = Random.Range(0, 5);

        if (spawnCounter <= 0 && dayNight.dayOver == false && canSpawn)
        {
            enemyCounter++;
            Instantiate(enemyList[randomEnemy], spawners[randomSpawn].gameObject.transform.position, 
                Quaternion.identity, spawnParent.transform);
            spawnCounter = spawnTime;
        }
    }
}
