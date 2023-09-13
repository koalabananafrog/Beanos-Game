using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLongBeno : MonoBehaviour
{
    public GameObject LongBenoPW;
    public GameObject Beanos;
    public void LongBeno(){
        Instantiate(LongBenoPW, Beanos.transform.position, Beanos.transform.rotation);
        FindObjectOfType<DataBase>().Coins = FindObjectOfType<DataBase>().Coins - 11;
        gameObject.SetActive(false);
    }
}
