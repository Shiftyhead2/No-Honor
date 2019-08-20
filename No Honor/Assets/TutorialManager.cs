using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [HideInInspector]
    public bool CompletedTutorial = false;

    public Text TutorialText;

    private void Start()
    {
        LoadPlayer();
        TutorialText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompletedTutorial)
        {
            TutorialText.enabled = false;
            return;
        }
        else
        {
            if(SpawnScript.WaveIndex == 0)
            {
                TutorialText.text = "Tutorial will start in the next wave";
            }
        
              else if (SpawnScript.WaveIndex == 1)
               {
                    
                    TutorialText.text = "Use WASD keys to move. Point the mouse and click the left mouse button to shoot a star";
               }
               else if (SpawnScript.WaveIndex == 2)
               {
                    TutorialText.text = "Press the spacebar to dash in the direction you are currently facing.";
               }
               else if (SpawnScript.WaveIndex > 2)
               {
                    CompletedTutorial = true;
                    Debug.Log("Saving data");
                    SavePlayer();
               }
      
        }

           
        
    }

    public void SavePlayer()
    {
        SaveData.SavePlayer(this);
    }

    public void LoadPlayer()
    {
       PlayerData data = SaveData.LoadPlayer();
       CompletedTutorial = data.CompletedTutorial;
    }

}
