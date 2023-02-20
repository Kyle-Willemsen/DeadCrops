using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth;
    public float enemyCurrentHealth;

    public float damage;

    public float basicZombieSpeed;
    public float currentSpeed;
    public float dontMove;

    public float detectionRadius;
    public LayerMask layerMask;
    bool canAttack;

    Image image;
    public Material flashMat;
    private Material originalMat;
    public float flashDuration;
    EnemyHealthBar healthBar;
    EnemySpawner enemySpawner;



    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        healthBar = GetComponent<EnemyHealthBar>();
        image = GetComponent<Image>();
        originalMat = image.material;
        canAttack = true;
        enemyCurrentHealth = enemyHealth;
        currentSpeed = basicZombieSpeed;
        flashMat = new Material(flashMat);
        healthBar.SetMaxHealth(enemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * currentSpeed * Time.deltaTime;
        currentSpeed = basicZombieSpeed;


        if (enemyCurrentHealth <= 0)
        {
            enemySpawner.enemyCounter--;
            Destroy(gameObject);
        }

        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);
        foreach (Collider2D col in collider)
        {
            if (col.GetComponent<House>())
            {
                col.GetComponent<House>().TakeALife(1);
                Destroy(gameObject);
                enemySpawner.enemyCounter--;
;           }

            if (col.GetComponent<DefenseStats>())
            {
                currentSpeed = dontMove;
                if (canAttack)
                {
                    canAttack = false;
                    col.GetComponent<DefenseStats>().TakeDamage(damage);
                    Invoke("ResetAttack", 2f);
                }
            }
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }


    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
        StartCoroutine(FlashMaterial());
        healthBar.SetHealth(enemyCurrentHealth);
    }

    private IEnumerator FlashMaterial()
    {
        image.material = flashMat;

        yield return new WaitForSeconds(flashDuration);
        image.material = originalMat;
    }
}
