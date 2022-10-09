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
    public void LevelThree()
    {
        if (LevelInformation.allLevels[2].IsUnlocked == true){
            SceneManager.LoadScene(LevelInformation.allLevels[2].LevelName);
            LevelInformation.CurrentLevel = LevelInformation.allLevels[2];
        }
    }
    public void LevelFour()
    {
        if (LevelInformation.allLevels[3].IsUnlocked == true){
            SceneManager.LoadScene(LevelInformation.allLevels[3].LevelName);
            LevelInformation.CurrentLevel = LevelInformation.allLevels[3];
        }
    }
    public void LevelFive()
    {
        if (LevelInformation.allLevels[4].IsUnlocked == true){
            SceneManager.LoadScene(LevelInformation.allLevels[4].LevelName);
            LevelInformation.CurrentLevel = LevelInformation.allLevels[4];
        }
    }
    public void LevelSix()
    {
        if (LevelInformation.allLevels[5].IsUnlocked == true){
            SceneManager.LoadScene(LevelInformation.allLevels[5].LevelName);
            LevelInformation.CurrentLevel = LevelInformation.allLevels[5];
        }
    }

}
