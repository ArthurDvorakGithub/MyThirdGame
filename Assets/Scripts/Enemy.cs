using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int healthEnemy = 3;

    public void TakeDamage(int damage)
    {
        healthEnemy -= damage;

        if(healthEnemy <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
