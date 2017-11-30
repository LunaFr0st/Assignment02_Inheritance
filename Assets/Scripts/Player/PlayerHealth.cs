using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject spawnPoint;
    public int health = 100;

    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint(Clone)");
    }

    void Update()
    {
        if(health <= 0)
        {
            transform.position = spawnPoint.transform.position;
            health = 100;
        }
    }
    public void DamageRecieve(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Debug.Log("bro did you just kill me bro, like bro, bro why you do dis bro!");
        }
    }
}
