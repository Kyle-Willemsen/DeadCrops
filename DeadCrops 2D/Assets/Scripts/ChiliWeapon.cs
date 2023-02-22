using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiliWeapon : MonoBehaviour
{
    public float explodeRadius;
    public LayerMask layerMask;

    public float tick;
    public float tickCounter;

    public float totalTime;
    public float initialDamage;
    public float tickDamage;
    bool canAttack;
    bool startTimer;

    private void Start()
    {
        canAttack = true;
        startTimer = false;
    }
    private void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);
        foreach (Collider2D col in collider)
        {
            if (col.GetComponent<EnemyStats>() && canAttack)
            {
                col.GetComponent<EnemyStats>().TakeDamage(initialDamage);
                canAttack = false;
                col.GetComponent<EnemyStats>().Tick();
                Destroy(gameObject);
                //startTimer = true;
            }
        }

        //totalTime = totalTime - 1 * Time.deltaTime;

       // if (tickCounter > 0)
       // {
       //     tickCounter -= 1 * Time.deltaTime;
       // }
       //
       // if (tickCounter <= 0)
       // {
       //     tickCounter = tick;
       // }
       //
       // if (startTimer)
       // {
       //     totalTime -= 1 * Time.deltaTime;
       //     if (totalTime <= 0)
       //     {
       //         Destroy(gameObject);
       //     }
       // }

        
    }

    public void Tick()
    {
        
    }
    public void TickReset()
    {

    }
}
