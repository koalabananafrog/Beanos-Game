using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeanosData : MonoBehaviour
{
    public float coins;
    public int levelStatus;
    public BeanosData (DataBase player){
        coins = player.Coins;
    }
}
