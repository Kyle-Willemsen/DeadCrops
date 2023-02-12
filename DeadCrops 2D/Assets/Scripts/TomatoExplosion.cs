using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoExplosion : MonoBehaviour
{
    public float explodeRadius;
    public float damage;
    public LayerMask layerMask;


    public void Explode()
    {
        CheckforEnemies();
        Destroy(gameObject, 0.1f);

    }
    public void CheckforEnemies()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);
        foreach (Collider2D obj in objects)
        {
            if (obj.GetComponent<EnemyStats>())
            {
                obj.GetComponent<EnemyStats>().TakeDamage(damage);
            }

        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}
