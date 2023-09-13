using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{
    public static int levelStatus = 3;
    public void Update(){
        if(Input.GetKey(KeyCode.K)){
            Debug.Log("K" + + levelStatus);
        }
    }
    
    public void Levelone()
    {
        if(levelStatus >= 2){
            SceneManager.LoadScene("Blevel1");
        }
        else{
            Debug.Log("false");
            Debug.Log(levelStatus + "Level");
        }
    }
    public void Leveltwo()
    {
        if(levelStatus >= 3){
            SceneManager.LoadScene(3);
        }
        else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelThree()
    {
         if(levelStatus >= 4){
            SceneManager.LoadScene(4);
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelFour()
    {
         if(levelStatus >= 5){
            SceneManager.LoadScene(5);
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelFive()
    {
         if(levelStatus >= 6){
            SceneManager.LoadScene(6);
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
    public void LevelSix()
    {
         if(levelStatus >= 7){
            SceneManager.LoadScene(7);
        }else{
            Debug.Log(levelStatus + "status");
        }
    }
}
