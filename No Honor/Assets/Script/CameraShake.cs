using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Range(0f,2f)]
    public float Intensity;


    Transform _transform;
    Vector3 initialPos;
    float pendingShakeDuration = 0f;
    bool isShaking = false;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        initialPos = _transform.localPosition;
        
    }

    public void Shake(float duration)
    {
        if(duration > 0f)
        {
            pendingShakeDuration += duration;
        }

    }

    private void Update()
    {
        if(pendingShakeDuration > 0f && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }

    IEnumerator DoShake()
    {
        isShaking = true;

        var StartTime = Time.realtimeSinceStartup;
        while(Time.realtimeSinceStartup < StartTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1f, 1f) * Intensity, Random.Range(-1f, 1f) * Intensity, initialPos.z);
            _transform.localPosition = randomPoint;
            yield return null;
        }

        pendingShakeDuration = 0f;
        _transform.localPosition = initialPos;
        isShaking = false;

    }

}
