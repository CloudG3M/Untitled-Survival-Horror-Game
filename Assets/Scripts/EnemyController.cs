using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target; 
    public float attackRange = 2f; 
    public int damageAmount = 25; 
    public float attackCooldown = 1f; 

    private PlayerHealth playerHealth;
    private float nextAttackTime;

    void Start()
    {
        playerHealth = target.GetComponent<PlayerHealth>(); 
        nextAttackTime = Time.time; 
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            
            if (Time.time >= nextAttackTime)
            {
                Attack();

                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Enemy dealt " + damageAmount + " damage to the player.");
        }
    }
}
