using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEat : MonoBehaviour
{
    [SerializeField] private Animator SpiderAnim;

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            SpiderAnim.SetBool("EatBeanos", true);
        }
    }
}
