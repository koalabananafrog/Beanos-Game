using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{
    [SerializeField] private GameObject Confetti;


      private void OnTriggerEnter(Collider other){
        Instantiate(Confetti, transform.position, transform.rotation);
        if (other.gameObject.layer == 11){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
