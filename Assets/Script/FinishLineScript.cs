using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{
    [SerializeField] private GameObject Confetti;
    [SerializeField] private GameObject BeanosTree;
    [SerializeField] private GameObject YoungBeanosTree;
    [SerializeField] private GameObject BabyBeanosTree;
    [SerializeField] private GameObject FetusBeanosTree;


      private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            DoVictoryScene();
            Debug.Log("Collision Working!");
        }
    }
     private void DoVictoryScene(){
        Debug.Log("Started!");
        Instantiate(FetusBeanosTree, transform.position, transform.rotation);
     }




    // IEnumerator DoVictoryScene()  //  <-  its a standalone method
    // {
    //     DoFetusBeanosTree();
    //     Debug.Log("Hey");
    //     yield return new WaitForSeconds(3);
    //     Debug.Log("H");
    //     DoBabyBeanosTree();
    //     yield return new WaitForSeconds(3);
    //     DoYoungBeanosTree();
    //     yield return new WaitForSeconds(3);
    //     DoBeanosTree();
    //     yield return new WaitForSeconds(6);
    //     DoNextScene();
    // }
    // private void DoFetusBeanosTree(){
    //     Instantiate(Confetti, transform.position, transform.rotation);
    //     Instantiate(FetusBeanosTree, transform.position, transform.rotation);
    // }
    // private void DoBabyBeanosTree(){
    //     Instantiate(BabyBeanosTree, transform.position, transform.rotation);
    // }
    // private void DoYoungBeanosTree(){
    //     Instantiate(YoungBeanosTree, transform.position, transform.rotation);
    // }
    // private void DoBeanosTree(){
    //     Instantiate(BeanosTree, transform.position, transform.rotation);
    // }
    // private void DoNextScene(){
    //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    // } 
}
