using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeanosData : MonoBehaviour
{
    public float Coins;
    public int LevelStatus;

    public BeanosData(DataBase data)
    {
        this.Coins = data.Coins;
        // this.LevelStatus = LevelMenu.levelStatus;
    }
}
