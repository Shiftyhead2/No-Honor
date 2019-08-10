using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float HP;
    public GameObject BloodParticles;

    
    // Update is called once per frame
    void Update()
    {
        if(HP <= 0f)
        {
            DestroyHumanoidObject();
        }
        
    }

    void DestroyHumanoidObject()
    {
        if(transform.tag == "Enemy")
        {
            SpawnScript.EnemiesAlive--;
        }

        Instantiate(BloodParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        HP -= damage;
    }
}
