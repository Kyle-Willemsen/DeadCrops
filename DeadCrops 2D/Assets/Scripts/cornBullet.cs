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
