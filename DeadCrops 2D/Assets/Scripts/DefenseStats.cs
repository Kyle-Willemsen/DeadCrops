using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseStats : MonoBehaviour
{
    public float health;
    public float currentHealth;


    private void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
