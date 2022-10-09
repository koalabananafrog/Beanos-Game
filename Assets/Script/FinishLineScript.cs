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
    private int currentLevelIndex;



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
        var index = Array.FindIndex<LevelInformation>(LevelInformation.allLevels, element => element == LevelInformation.CurrentLevel);
            index = currentLevelIndex;
            Debug.Log(currentLevelIndex);
        LevelInformation.allLevels[currentLevelIndex].IsUnlocked = true;
        Debug.Log(LevelInformation.allLevels[currentLevelIndex++].IsUnlocked);
     }

     IEnumerator DoNextLevel()
     {
        yield return new WaitForSeconds(15);
    
        SceneManager.LoadScene(LevelInformation.allLevels[currentLevelIndex].LevelName);
     }

}
