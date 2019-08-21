using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public bool CompletedTutorial;

    public PlayerData(TutorialManager player)
    {
        CompletedTutorial = player.CompletedTutorial;
    }
}
