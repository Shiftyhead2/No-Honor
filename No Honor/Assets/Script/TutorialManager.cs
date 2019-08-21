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
            switch (SpawnScript.WaveIndex)
            {
                case 3:
                    CompletedTutorial = true;
                    //Debug.Log("Saving data");
                    SavePlayer();
                    break;
                case 2:
                    TutorialText.text = "Press the spacebar to dash in the direction you are currently facing.";
                    break;
                case 1:
                    TutorialText.text = "Use WASD keys to move. Point the mouse and click the left mouse button to shoot a star";
                    break;
                case 0:
                    TutorialText.text = "Tutorial will start in the next wave";
                    break;
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
