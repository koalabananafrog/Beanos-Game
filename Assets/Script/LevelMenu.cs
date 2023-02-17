using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{
    private int levelStatus = 1;
    public void Levelone()
    {
        if(levelStatus >= 1){
            SceneManager.LoadScene("Level1");
        }
    }
    public void Leveltwo()
    {
       
    }
    public void LevelThree()
    {
        
    }
    public void LevelFour()
    {

    }
    public void LevelFive()
    {
        
    }
    public void LevelSix()
    {
        
    }
}
