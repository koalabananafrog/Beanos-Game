using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    [SerializeField] public GameObject nointernet;
    public void Respawn()
    {
        DataBase dataBase = FindObjectOfType<DataBase>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SaveSystem.SavePlayer(dataBase);
    }

    public void Menu()
    {
        DataBase dataBase = FindObjectOfType<DataBase>();
        SceneManager.LoadScene("MenuAlpha1");
        SaveSystem.SavePlayer(dataBase);
    }
}
