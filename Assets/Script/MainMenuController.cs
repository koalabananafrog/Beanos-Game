using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void LoadPlayer(DataBase dataBase){
        BeanosData data = SaveSystem.LoadPlayer();
        dataBase.Coins = data.Coins;
    }
    
    private void bajs(){
        
    }
}
