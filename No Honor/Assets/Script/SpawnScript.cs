using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    public Transform[] SpawnPoints;

    public float TimeBetweenWaves = 5f;
    private float Countdown = 2f;
    private int WaveIndex = 0;

    public Text WaveText;
    public Text EnemiesRemainingText;
    [TextArea]
    public string[] Taunts;
    private bool HasChosen = false;


    

    // Update is called once per frame
    void Update()
    {
        EnemiesRemainingText.text = "ENEMIES ALIVE:" + EnemiesAlive.ToString();
        if (EnemiesAlive > 0)
        {
            return;
        }
        else if(EnemiesAlive == 0)
        {
            if (!HasChosen)
            {
                WaveText.text = Taunts[Random.Range(0, Taunts.Length)];
                HasChosen = true;
            }
            
        }

        if(Countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            Countdown = TimeBetweenWaves;
            WaveText.text = "WAVE " + WaveIndex.ToString();
            HasChosen = false;
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
