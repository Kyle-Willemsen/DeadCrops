using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseStats : MonoBehaviour
{
    public float health;
    public float currentHealth;

   //Image image;
   //public Material flashMat;
   //private Material originalMat;
   //public float flashDuration;


    private void Start()
    {
        currentHealth = health;
        //image = GetComponent<Image>();
        //originalMat = image.material;
        //flashMat = new Material(flashMat);

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
        //StartCoroutine(FlashMaterials());
    }

    //private IEnumerator FlashMaterials()
    //{
    //    image.material = flashMat;
    //
    //    yield return new WaitForSeconds(flashDuration);
    //    image.material = originalMat;
    //}
}
