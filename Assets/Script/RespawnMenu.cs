using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{

    private void Update()
    {
       
        

        
    }



    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuAlpha1");
    }

    public void Levelone()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Leveltwo()
    {
        SceneManager.LoadScene("Level2");
    }




}
