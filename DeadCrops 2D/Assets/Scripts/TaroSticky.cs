using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaroSticky : MonoBehaviour
{
    EnemyStats enemyStats;
    public float stickyRadius;
    public LayerMask layermask;
    public float slowSpeed;
    public GameObject point1;
    public GameObject point2;


    private void Start()
    {
        //enemyStats = GameObject.FindWithTag("Enemies").GetComponent<EnemyStats>();
        //slowSpeed = enemyStats.currentSpeed * -2f; 
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapAreaAll(point1.transform.position,  point2.transform.position, layermask);
        foreach (Collider2D col in colliders)
        {
            if (col.GetComponent<EnemyStats>())
            {
                col.GetComponent<EnemyStats>().SlowEnemy(slowSpeed);
                Destroy(gameObject, 10);
            }
        }
    }
}
