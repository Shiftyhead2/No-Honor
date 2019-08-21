using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public float HP;
    public GameObject BloodParticles;
    public CameraShake CameraShaker;
    public AudioClip DeathSound;
    public float Duration = 1f;

    
    // Update is called once per frame
    void Update()
    {
        CameraShaker = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        if(HP <= 0f)
        {
            DestroyHumanoidObject();
        }
        
    }

    void DestroyHumanoidObject()
    {
        if(transform.CompareTag("Player"))
        {
            GameOverManager.GameOver = true;
        }

        if(transform.CompareTag("Enemy"))
        {
            SpawnScript.EnemiesAlive--;
        }


        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Instantiate(BloodParticles, transform.position, Quaternion.identity);
        CameraShaker.Shake(Duration);
        Destroy(gameObject);
    }

    public void Damage(float damage)
    {
        HP -= damage;
    }
}
