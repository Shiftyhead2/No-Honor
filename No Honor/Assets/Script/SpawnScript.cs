using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Transform enemyPrefab;
    public Transform SpawnPoint;
    public float SpawnRadius;

    public float TimeBetweenWaves = 5f;
    private float Countdown = 2f;
    public static int WaveIndex = 0;

    public Canvas UI;
    public Text WaveText;
    public Text EnemiesRemainingText;
    [TextArea]
    public string[] Taunts;
    private bool HasChosen = false;


    private void Start()
    {
        WaveIndex = 0;
        EnemiesAlive = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameOverManager.GameOver)
        {
            UI.enabled = false;
            return;
        }

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
        Vector2 _sp = SpawnPoint.position;
        _sp += Random.insideUnitCircle.normalized * SpawnRadius;
        Instantiate(enemyPrefab, _sp,Quaternion.identity);
        EnemiesAlive++;
    }

}
