using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int damage = 25;

    public float timer;
    float attackRate = 0.5f;

    public bool canAttack = false;

    PlayerHealth pHealth;
    void Awake()
    {
        pHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    { 
        
    }
    void DamageRecieve(int damageTaken)
    {
        health -= damageTaken;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void DamageGive(int damageDealt)
    {
        pHealth.DamageRecieve(damageDealt);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            DamageGive(damage);
        }
    }
}
