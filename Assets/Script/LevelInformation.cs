using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInformation : MonoBehaviour
{   
    public static bool CurrentLevel;

    public string LevelName; 
    public bool IsUnlocked;

    public LevelInformation(string name) {
        LevelName = name;
        IsUnlocked = false;
    }

    public static LevelInformation[] allLevels = {
        new LevelInformation("Level1"),
        new LevelInformation("level2"),
        new LevelInformation("Third"),
        new LevelInformation("Fourth"),
    }; 


    public void unlock() {
        IsUnlocked = true;
    }


}





