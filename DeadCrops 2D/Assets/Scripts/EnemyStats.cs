using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth;
    public float enemyCurrentHealth;

    public float damage;

    public float basicZombieSpeed;
    public float currentSpeed;
    public float dontMove;


    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyHealth;
        currentSpeed = basicZombieSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * currentSpeed * Time.deltaTime;

        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Defenses")
        {
            currentSpeed = dontMove;
            other.GetComponent<DefenseStats>().TakeDamage(damage);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Defenses")
        {
            currentSpeed = dontMove;
        }
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
    }
}
