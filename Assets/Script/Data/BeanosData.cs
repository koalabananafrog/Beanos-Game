using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeanosData
{
    public float Coins = 0;
    public int LevelStatus = 2;

    public BeanosData(DataBase data)
    {
        this.Coins = data.Coins;
        
    }
}
