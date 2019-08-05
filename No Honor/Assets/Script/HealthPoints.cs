using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float HP;

    
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
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        HP -= damage;
    }
}
