using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornExplosion : MonoBehaviour
{
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    public Transform bulletSpawn4;
    public float force;
    public GameObject cornBullet;
    public float resetShot;
    public float bulletCount;
    public bool canShoot = true;


    private void Start()
    {
        Invoke("Shoot", 0.1f);

    }
    private void Update()
    {
        if (bulletCount <= 0)
        {
            canShoot = false;
            Destroy(gameObject, 1);
        }
    }

    private void ResetShot()
    {
        Invoke("Shoot", resetShot);
    }


    private void Shoot()
    {
        if (canShoot)
        {
            var currentBullet =
            Instantiate(cornBullet, bulletSpawn1.position, bulletSpawn1.rotation);
            Instantiate(cornBullet, bulletSpawn2.position, bulletSpawn2.rotation);
            Instantiate(cornBullet, bulletSpawn3.position, bulletSpawn3.rotation);
            Instantiate(cornBullet, bulletSpawn4.position, bulletSpawn4.rotation);
            ResetShot();
            bulletCount--;
        }
    }

    
}
