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
    public CameraScript cameraScript;
    private bool launchBall = false;
    private float Smoothness = 1;
    public GameObject Ball;
    private float TreeCount = 1; 
     private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            DoVictoryScene();
        }
        if (launchBall == true){
            Vector3 desiredPosition = Ball.transform.position + new Vector3(0, 1, 0);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness);
            transform.position = smoothedPosition;
        }
    }
     private void DoVictoryScene()
     {
        if (TreeCount == 1)
        {
            Instantiate(FetusBeanosTree, transform.position, transform.rotation);
            TreeCount--;
        }
        
        launchBall = true;
        cameraScript.FollowTreeGrowth = true;
     }

}
