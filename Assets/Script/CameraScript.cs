using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CameraScript : MonoBehaviour
{
     public Transform Target;
     private bool FollowBeanos; 
     public bool FollowTreeGrowth; 
     public Vector3 offset;
     public float Smoothness = 0.125f;
    
    
    private void Start()
    {
        FollowBeanos = true;
        FollowTreeGrowth = false;
    }

private void FixedUpdate()
    {
         if(FollowTreeGrowth == true){
            FollowBeanos = false;
        }
        if(FollowBeanos == true)
        {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness);
        transform.position = smoothedPosition;
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
