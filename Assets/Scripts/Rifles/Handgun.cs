using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamage = 10f;
    public float shootingRange = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }
    void Shoot()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hitInfo,shootingRange))
        {
            Debug.Log(hitInfo.transform.name);

            Object obj = hitInfo.transform.GetComponent<Object>();

            if(obj!= null)
            {
                obj.ObjectHitDamage(giveDamage);
            }
        }
    }
}
