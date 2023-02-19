using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableWeapons : MonoBehaviour
{
    public bool isEnabled;
    public GameObject weapon;
    public LayerMask layerMask;
    private void Update()
    {
        if (isEnabled)
        {
            weapon.transform.position = Input.mousePosition;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("HitEnemy");
            }
        }
    }
    public void ClickButton()
    {
        if (!isEnabled)
        {
            isEnabled = true;
            weapon.SetActive(true);
        }
        if (isEnabled)
        {
            isEnabled = false;
            weapon.SetActive(false);
        }
    }
}
