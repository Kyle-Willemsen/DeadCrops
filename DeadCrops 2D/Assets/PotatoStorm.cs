using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoStorm : MonoBehaviour
{
    public float potatoDamage;
    public GameObject point1;
    public GameObject point2;
    public LayerMask layerMask;

    private void Update()
    {

    }

    public void ResetTick()
    {
        Tick();
    }

    public void Tick()
    {
        Collider2D[] collider = Physics2D.OverlapAreaAll(point1.transform.position, point2.transform.position, layerMask);
        foreach (Collider2D col in collider)
        {
            if (col.GetComponent<EnemyStats>())
            {
                col.GetComponent<EnemyStats>().TakeDamage(potatoDamage);
            }
        }
        Invoke("ResetTick", 0.5f);
    }
}
