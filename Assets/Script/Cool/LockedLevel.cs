using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedLevel : MonoBehaviour
{
 [SerializeField] private int X;
void Awake(){
    DataBase dataBase = FindObjectOfType<DataBase>();
    if(dataBase.LevelStatus >= X){
        Destroy(gameObject);
        Debug.Log("?Done");
    }
    Debug.Log("?hey" +" "+ this + " " + X + " " + dataBase.LevelStatus);
}
}
