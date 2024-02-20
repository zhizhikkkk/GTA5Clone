using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamage = 10f;
    public float shootingRange = 100f;
    public float fireCharge = 10f;
    private float nextTimeToShoot = 0f;

    [Header("Rifle Ammunition and reloading")]
    private int maximumAmmunition = 25;
    public int mag = 10;
    public int presentAmmunition;
    public float reloadingTime = 4.3f;
    private bool setReloading = false;


    [Header("Rifle Effects")]
    public ParticleSystem muzzleSpark;
    public GameObject metallEffect;

    [Header("Sounds && UI")]
    public GameObject AmmoOutUI; 
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        presentAmmunition = maximumAmmunition;
    }

    void Update()
    {
        if(setReloading)
        {
            return;
        }
        if (presentAmmunition <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >=nextTimeToShoot)
        {
            nextTimeToShoot = Time.time+1f/fireCharge;
            Shoot();
        }
        
    }
    void Shoot()
    {
        if (mag == 0)
        {
            StartCoroutine (ShowAmmoOut());
            return;
        }
        presentAmmunition--;
        if (presentAmmunition == 0)
        {
            mag--;

        }
        muzzleSpark.Play();
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hitInfo,shootingRange))
        {
            Debug.Log(hitInfo.transform.name);

            Object obj = hitInfo.transform.GetComponent<Object>();

            if(obj!= null)
            {
                obj.ObjectHitDamage(giveDamage);

                
            }
            GameObject metalEffectGo =Instantiate(metallEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(metalEffectGo,1f);
        }
    }
    
    IEnumerator Reload()
    {
        setReloading = true;
        Debug.Log("reloading...");
        yield return new WaitForSeconds(reloadingTime);

        Debug.Log("Done reloading");
        presentAmmunition=maximumAmmunition;
        setReloading = false;
    }

    IEnumerator ShowAmmoOut()
    {
        AmmoOutUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmoOutUI.SetActive(false);
    }
}
