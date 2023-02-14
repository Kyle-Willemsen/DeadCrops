using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingCarrot : MonoBehaviour
{
    public float damage;
    public float speed;
    public float collisionRadius;
    public LayerMask layermask;
    public bool canApplyDamage;


    private void Start()
    {
        canApplyDamage = true;
    }

    private void Update()
    {
        Shoot();
        Destroy(gameObject, 1.2f);
    }


    private void Shoot()
    {
        transform.position += speed * Time.deltaTime * transform.right;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, collisionRadius, layermask);

        foreach (Collider2D col in colliders)
        {
            if (col.GetComponent<EnemyStats>() && canApplyDamage)
            {
                col.GetComponent<EnemyStats>().TakeDamage(damage);
                canApplyDamage = false;
                Invoke("ResetShot", 0.2f);
            }
        }

    }

    public void ResetShot()
    {
        canApplyDamage = true;
    }
}
