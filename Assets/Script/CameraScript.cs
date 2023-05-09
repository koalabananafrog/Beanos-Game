using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CameraScript : MonoBehaviour
{
     public Transform Target;
     public Transform Tree;
     private bool FollowBeanos; 
     public bool FollowTreeGrowth; 
     public Vector3 offset;
     public float Smoothness = 0.125f;
     [SerializeField] private bool wormyRot = false;
     public float rotateSpeed=2f;
     private bool rotateRight;
     private bool rotateLeft;
     private Vector3 vector3Manos = new Vector3(50, 5, 4);
    
    private void Start()
    {
        FollowBeanos = true;
        FollowTreeGrowth = false;
        
        if(wormyRot){
            StartCoroutine(RotateCamera());
        }
        else{
            Debug.Log("Help");
        }
    }

private void FixedUpdate()
    {
         if(FollowTreeGrowth == true){
            FollowBeanos = false;
            offset = new Vector3(0, 1, -15.5f);
            Vector3 desiredPosition = Tree.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness);
            transform.position = smoothedPosition;
        }
        if(FollowBeanos == true)
        {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness);
        transform.position = smoothedPosition;
        }
        if(rotateRight){
            transform.RotateAround(Target.position, Vector3.down, rotateSpeed* Time.deltaTime);
        }
        if(rotateLeft){
            transform.RotateAround(Target.position, Vector3.up, rotateSpeed* Time.deltaTime);
        }
        


        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuAlpha1");
        }
    }
    private IEnumerator RotateCamera(){
        rotateRight = true;
        offset = vector3Manos;
        yield return new WaitForSeconds(1.5f);
        rotateRight = false;
        yield return new WaitForSeconds(3);
        rotateLeft = true;
        offset = new Vector3(0, 1, -15.5f);    
        yield return new WaitForSeconds(1.5f);
        rotateLeft = false;       
    }
}
