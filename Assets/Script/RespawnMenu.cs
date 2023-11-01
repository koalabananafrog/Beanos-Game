using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    private int Rando;
    public void Respawn()
    {
        DataBase dataBase = FindObjectOfType<DataBase>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SaveSystem.SavePlayer(dataBase);
        Rando = Random.Range(0, 3);
        if(Rando <= 1){
            FindObjectOfType<InterstitialAd>().ShowAd();
        }
        Debug.Log(Rando);
    }

    public void Menu()
    {
        DataBase dataBase = FindObjectOfType<DataBase>();
        SceneManager.LoadScene("MenuAlpha1");
        SaveSystem.SavePlayer(dataBase);
    }
}
