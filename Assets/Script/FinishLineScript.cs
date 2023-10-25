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
    // private bool launchBall = false;
    private float TreeCount = 1;
    public static int levelStatus;
    private int Q;
    public DataBase dataBase;
    public int finishLineScriptLevelStatus = 2;
     private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == 11){
            DoVictoryScene();
            StartCoroutine(DoNextLevel());
        }
    }
     private void DoVictoryScene()
     {
        dataBase = FindObjectOfType<DataBase>();


        Q = SceneManager.GetActiveScene().buildIndex + 1; 
        if(Q>levelStatus){
            levelStatus = Q;
        }
        if (TreeCount == 1)
        {
            Instantiate(FetusBeanosTree, transform.position, transform.rotation);
            TreeCount--;
            InvisableCube.SetBool("TreeGrowing", true);
            beanosScript.makeCollisionFalse = true;
            beanosScript.freezeX = true;
        }
        // launchBall = true;
        cameraScript.FollowTreeGrowth = true;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        dataBase.LevelStatus = nextScene;
        Debug.Log(dataBase.LevelStatus + "status");


          
        SaveSystem.SavePlayer(dataBase);
     }

     IEnumerator DoNextLevel()
     {
        yield return new WaitForSeconds(15);

        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
     }

}
