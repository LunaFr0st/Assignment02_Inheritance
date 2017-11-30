using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public int damage = 50;
    

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            EnemyHealth e = col.GetComponent<EnemyHealth>();
            if (e != null)
            {
                e.DamageReceive(damage);
                Destroy(gameObject);
            }
            
        }
        if(col.gameObject.tag == "Box")
        {
            Destroy(gameObject);
        }
    }
}
