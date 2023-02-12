using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cornBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Transform parent;
    //public Rigidbody2D rb;
    private void Start()
    {
        Destroy(gameObject, 3);
    }


    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        parent = transform.parent;
        transform.SetParent(parent);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {
            GetComponent<EnemyStats>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
