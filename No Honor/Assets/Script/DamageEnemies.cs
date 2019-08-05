using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemies : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealthPoints>().Damage(Damage);
            DestroyProjective();
        }
        else
        {
            //Do nothing
        }
    }

    void DestroyProjective()
    {
        Destroy(gameObject);
    }
}
