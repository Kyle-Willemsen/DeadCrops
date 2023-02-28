using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class weaponWatermelon : MonoBehaviour
{
    public float rollSpeed;
    public float waterDamage;
    public float radius;
    public LayerMask layerMask;
    //Animator anim;
    public GameObject roller;
    public GameObject parent;


    private void Start()
    {
        Destroy(parent, 3);
        //anim = GetComponent<Animator>();
        //anim.Play("WatermelonRoll");
    }

    private void Update()
    {
        Roll();
    }

    public void Roll()
    {
        roller.transform.Rotate(0, 0, -100 * Time.deltaTime, Space.Self);
        waterDamage += 50 * Time.deltaTime;
        rollSpeed += 200 * Time.deltaTime;

        transform.position += rollSpeed * Time.deltaTime * transform.right;

        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);
        foreach (Collider2D col in collider)
        {
            if (col.GetComponent<EnemyStats>())
            {
                col.GetComponent<EnemyStats>().TakeDamage(waterDamage);
                Destroy(parent);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
