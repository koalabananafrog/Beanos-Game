using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{
    public static int levelStatus = 2;
    
    public void Levelone()
    {
        if(levelStatus >= 2){
            SceneManager.LoadScene("Level1");
        }
        else{
            Debug.Log("false");
            Debug.Log(levelStatus + "Level");
        }
    }
    public void Leveltwo()
    {
        if(levelStatus >= 3){
            SceneManager.LoadScene("Level2");
        }
        else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelThree()
    {
         if(levelStatus >= 4){
            SceneManager.LoadScene("Level3");
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelFour()
    {
         if(levelStatus >= 5){
            SceneManager.LoadScene("Level4");
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelFive()
    {
         if(levelStatus >= 6){
            SceneManager.LoadScene("Level5");
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelSix()
    {
         if(levelStatus >= 7){
            SceneManager.LoadScene("Level6");
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
}
