using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void Levelone()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Leveltwo()
    {
        SceneManager.LoadScene("Level2");
    }

}
