using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanosEat : MonoBehaviour
{   
    [SerializeField] public Animator AnimatorController;
   private void OnTriggerEnter(Collision collision){
    if (collision.gameObject.layer == 11){
        AnimatorController.SetBool("EatBeanos", true);
    }
   }
}
