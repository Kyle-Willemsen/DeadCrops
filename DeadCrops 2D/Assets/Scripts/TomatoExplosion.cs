using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoExplosion : MonoBehaviour
{
    public float explodeRadius;
    public float damage;
    public LayerMask layerMask;
    public bool tomato;
    public bool pumpkin;
    public GameObject crackedPumpkin;
    public GameObject pumpkinImage;



    public void Explode()
    {
        CheckforEnemies();
        if (tomato)
        {
            Destroy(gameObject, 0.1f);
        }
        if (pumpkin)
        {
            Destroy(gameObject, 0.2f);
        }

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

    public void CrackedPump()
    {
        pumpkinImage.SetActive(false);
        crackedPumpkin.SetActive(true);
    }
}
