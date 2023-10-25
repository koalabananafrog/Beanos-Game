using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public DataBase dataBase;
    private int translatedStatus;
    public void playGame()
    {
        SceneManager.LoadScene("LevelMenu");
        
        
        dataBase = FindObjectOfType<DataBase>();
        BeanosData data = SaveSystem.LoadPlayer();
        DataBase.Instance.Coins = data.Coins;
        DataBase.Instance.LevelStatus = data.LevelStatus;

        Debug.Log("hi" + data.Coins + "status" + data.LevelStatus);
    }
}
