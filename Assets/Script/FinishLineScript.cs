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
    private float TreeCount = 1;

    
    

     private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            DoVictoryScene();
            StartCoroutine(DoNextLevel());
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
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        LevelMenu.levelStatus = nextScene;
        Debug.Log(LevelMenu.levelStatus + "status");
     }

     IEnumerator DoNextLevel()
     {
        yield return new WaitForSeconds(15);

        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
     }

}
