using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishLineScript : MonoBehaviour
{
    [SerializeField] private GameObject Confetti;
    [SerializeField] private GameObject BeanosTree;
    [SerializeField] private GameObject YoungBeanosTree;
    [SerializeField] private GameObject BabyBeanosTree;
    [SerializeField] private GameObject FetusBeanosTree;

    public bool executeBeanos = false;


     private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            DoVictoryScene();
            Debug.Log("Collision Working!");
        }
    }
     private void DoVictoryScene(){
        executeBeanos = false;
        Debug.Log("Started!");
        Instantiate(FetusBeanosTree, transform.position, transform.rotation);
     }
}
