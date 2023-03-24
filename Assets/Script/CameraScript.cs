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
     
    
    
    private void Start()
    {
        FollowBeanos = true;
        FollowTreeGrowth = false;
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
        if(wormyRot && transform.rotation.y == 0){
            transform.Rotate(0, 1, 0);
        }
        else{
            Debug.Log("Help");
        }
        


        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuAlpha1");
        }
    }
}
