using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void Levelone()
    {
        if (LevelInformation.allLevels[0].IsUnlocked == true){
            SceneManager.LoadScene(LevelInformation.allLevels[0].LevelName);
            LevelInformation.CurrentLevel = LevelInformation.allLevels[0];
        }
    }

    public void Leveltwo()
    {
        if (LevelInformation.allLevels[1].IsUnlocked == true){
            SceneManager.LoadScene(LevelInformation.allLevels[1].LevelName);
            LevelInformation.CurrentLevel = LevelInformation.allLevels[1];
        }
    }

}
