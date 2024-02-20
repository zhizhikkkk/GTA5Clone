using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float ObjectHealth=120f;

    public void ObjectHitDamage(float amount)
    {
        ObjectHealth -= amount;

        if (ObjectHealth <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
