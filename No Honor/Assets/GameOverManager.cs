using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static bool GameOver;
    public Canvas DeathUI;
    public Text GameOverText;
    private Animator DeathAnimator;


    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        DeathAnimator = DeathUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            Dead();
        }
        
    }

    void Dead()
    {
        DeathAnimator.SetBool("GameOver", true);
        if(SpawnScript.WaveIndex <= 1)
        {
            GameOverText.text = "You seriously died on the first wave?";
        }
        else if(SpawnScript.WaveIndex <= 2)
        {
            GameOverText.text = "Did you seriously die on wave 2?";
        }
        else
        {
            GameOverText.text = "You survived " + SpawnScript.WaveIndex.ToString() + " waves";
        }
       

    }

    public void RestartGame()
    {
        GameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
