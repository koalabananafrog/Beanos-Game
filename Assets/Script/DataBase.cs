using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static DataBase Instance;
    public float Coins;

    private void Awake()
    {
  
  // start of new code
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);
    }
}