using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLongBeno : MonoBehaviour
{
    public GameObject LongBenoPW;
    public GameObject Beanos;

    public void LongBeno(){
        Instantiate(LongBenoPW, Beanos.transform.position, Beanos.transform.rotation);
        Beanos.GetComponent<BeanosPlayer>().Coins = Beanos.GetComponent<BeanosPlayer>().Coins - 20;
        gameObject.SetActive(false);
    }
}
