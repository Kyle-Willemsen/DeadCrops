using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cornBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Transform parent;
    GameObject UI;
    DragDrop dragdrop;
    //public Rigidbody2D rb;

    public float collisionRadius;
    public LayerMask layermask;


    private void Start()
    {
        Destroy(gameObject, 5);
        UI = GameObject.FindGameObjectWithTag("UI");

        parent = UI.transform;
        transform.SetParent(parent);
    }


    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        transform.position += speed * Time.deltaTime * transform.up;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, collisionRadius, layermask);

        foreach (Collider2D col in colliders)
        {
            if (col.GetComponent<EnemyStats>())
            {
                col.GetComponent<EnemyStats>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collisionRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("Contact");
            GetComponent<EnemyStats>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
