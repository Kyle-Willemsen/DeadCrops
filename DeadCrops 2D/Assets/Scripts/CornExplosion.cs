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


    private void Start()
    {
        Shoot();
    }

    private void ResetShot()
    {
        Invoke("Shoot", 2);
    }


    private void Shoot()
    {
        var currentBullet =
        Instantiate(cornBullet, bulletSpawn1.position, bulletSpawn1.rotation);
        Instantiate(cornBullet, bulletSpawn2.position, bulletSpawn2.rotation);
        Instantiate(cornBullet, bulletSpawn3.position, bulletSpawn3.rotation);
        Instantiate(cornBullet, bulletSpawn4.position, bulletSpawn4.rotation);
        ResetShot();
    }

    
}
