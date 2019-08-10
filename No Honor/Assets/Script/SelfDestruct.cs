using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private ParticleSystem PS;
    float duration;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
        duration = PS.duration + PS.startLifetime;
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);
        
    }
}
