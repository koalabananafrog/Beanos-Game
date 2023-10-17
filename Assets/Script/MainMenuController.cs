using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public DataBase dataBase;
    public void playGame()
    {
        SceneManager.LoadScene("LevelMenu");
        dataBase = FindObjectOfType<DataBase>();
        BeanosData data = SaveSystem.LoadPlayer();
        DataBase.Instance.Coins = data.Coins;
        Debug.Log(SaveSystem.LoadPlayer());
    }
}
