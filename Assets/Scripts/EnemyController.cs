using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; 
    public float attackRange = 2f; 
    public int damageAmount = 25; 

    private PlayerHealth playerHealth;
    private bool hasAttacked = false; 

    void Start()
    {
        playerHealth = target.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            Attack();
        }
        else
        {
            hasAttacked = false; 
        }
    }

    void Attack()
    {
        Debug.Log("Enemy is attacking!");
        if (!hasAttacked)
        {
            Debug.Log("Enemy is dealing damage to the player.");
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            hasAttacked = true;
        }
    }
}
