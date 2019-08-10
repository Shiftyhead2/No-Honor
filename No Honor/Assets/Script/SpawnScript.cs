using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    public Transform[] SpawnPoints;

    public float TimeBetweenWaves = 5f;
    private float Countdown = 2f;
    private int WaveIndex = 0;


    

    // Update is called once per frame
    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if(Countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            Countdown = TimeBetweenWaves;
            return;
        }
        Countdown -= Time.deltaTime;
        
    }

    IEnumerator SpawnWave()
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }
    }

    void SpawnEnemy()
    {
        Transform _sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(enemyPrefab, _sp.position, _sp.rotation);
        EnemiesAlive++;
    }

}
