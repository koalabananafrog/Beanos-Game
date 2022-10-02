using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Start(){
        LevelInformation.allLevels[0].IsUnlocked = true;
    }
    public void playGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    
    private void bajs(){
        
    }
}
