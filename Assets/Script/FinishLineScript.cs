using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FinishLineScript : MonoBehaviour
{
    [SerializeField] private GameObject FetusBeanosTree;
    [SerializeField] private Animator InvisableCube;
    public BeanosPlayer beanosScript;
    public CameraScript cameraScript;
    private bool launchBall = false;
    private float Smoothness = 1;
    private float TreeCount = 1;
    private string[] Levels = {"Level1", "Level2"};
    private string currentScene;
    private int a;
    private int b; 
    
     private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            DoVictoryScene();
            StartCoroutine(DoNextLevel());
            LevelInformationScript.Level = a;
            b = a++;
        }
    }
     private void DoVictoryScene()
     {
        if (TreeCount == 1)
        {
            Instantiate(FetusBeanosTree, transform.position, transform.rotation);
            TreeCount--;
            InvisableCube.SetBool("TreeGrowing", true);
            beanosScript.makeCollisionFalse = true;
        }
        launchBall = true;
        cameraScript.FollowTreeGrowth = true;
     }

     IEnumerator DoNextLevel()
     {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(Levels[b]);
     }

}
