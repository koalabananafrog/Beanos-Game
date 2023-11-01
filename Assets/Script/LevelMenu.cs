using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class LevelMenu : MonoBehaviour
{   
    private float Rando;
    private void Awake(){
        levelStatus = FindObjectOfType<DataBase>().LevelStatus;
    }
    private int levelStatus;

    public void Levelone()
    {
        if(levelStatus >= 2){
            SceneManager.LoadScene("Blevel1");
        }
        else{
            Debug.Log("false");
            Debug.Log(levelStatus + "Level");
        }
        Advertisement.Banner.Hide();
    }
    public void Leveltwo()
    {
        if(levelStatus >= 3){
            SceneManager.LoadScene(3);
        }
        else{
            Debug.Log(levelStatus + "status");
        }
        Advertisement.Banner.Hide();
        FindObjectOfType<InterstitialAd>().ShowAd();
    }
    public void LevelThree()
    {
         if(levelStatus >= 4){
            SceneManager.LoadScene(4);
        }else{
            Debug.Log(levelStatus + "status");
        }
        Advertisement.Banner.Hide();
        FindObjectOfType<InterstitialAd>().ShowAd();
    }
    public void LevelFour()
    {
         if(levelStatus >= 5){
            SceneManager.LoadScene(5);
        }else{
            Debug.Log(levelStatus + "status");
        }
        Advertisement.Banner.Hide();
        FindObjectOfType<InterstitialAd>().ShowAd();
    }
    public void LevelFive()
    {
         if(levelStatus >= 6){
            SceneManager.LoadScene(6);
        }else{
            Debug.Log(levelStatus + "status");
        }
        Advertisement.Banner.Hide();
        FindObjectOfType<InterstitialAd>().ShowAd();
    }
    public void LevelSix()
    {
         if(levelStatus >= 7){
            SceneManager.LoadScene(7);
        }else{
            Debug.Log(levelStatus + "status");
        }
        Advertisement.Banner.Hide();
        FindObjectOfType<InterstitialAd>().ShowAd();
    }
}
