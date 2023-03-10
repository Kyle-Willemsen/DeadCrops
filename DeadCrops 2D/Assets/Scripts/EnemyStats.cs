using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth;
    public float enemyCurrentHealth;

    public float damage;

    public float originalSpeed;
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
    DayNightCycle dayNightCycle;

    public bool canJump;
    public Animator anim;
    public ChiliWeapon chiliWeapon;
    public float tickDamage;
    public float tickCounter;



    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        enemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        dayNightCycle = GameObject.Find("GameManager").GetComponent<DayNightCycle>();
        healthBar = GetComponent<EnemyHealthBar>();
        image = GetComponent<Image>();
        originalMat = image.material;
        canAttack = true;
        enemyCurrentHealth = enemyHealth;
        currentSpeed = originalSpeed;
        flashMat = new Material(flashMat);
        healthBar.SetMaxHealth(enemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * currentSpeed * Time.deltaTime;
        currentSpeed = originalSpeed;

        if (dayNightCycle.currentDay <= 5)
        {
            currentSpeed += 2;
        }
        if (dayNightCycle.currentDay <= 10)
        {
            currentSpeed += 2;
        }
        if (dayNightCycle.currentDay <= 15)
        {
            currentSpeed += 2;
        }

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
                if (canJump)
                {
                    anim.SetBool("Jump", true);
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
        //if (chiliWeapon.tickCounter == 1)
        //{
           // enemyCurrentHealth -= chiliWeapon.tickDamage;
        //}
    }

    public void TickTimer()
    {

        Tick();
    }

    public void Tick()
    {
        if (tickCounter > 0)
        {
            TakeDamage(tickDamage);
        }
        tickCounter--;

        Invoke("TickTimer", 2);
    }

    public void SlowEnemy(float slowSpeed)
    {

        currentSpeed = slowSpeed;
    }

    private IEnumerator FlashMaterial()
    {
        image.material = flashMat;

        yield return new WaitForSeconds(flashDuration);
        image.material = originalMat;
    }
}
