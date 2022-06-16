using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CameraScript : MonoBehaviour
{
     public Transform Target;

     private BeanosPlayer player;

    [SerializeField] private AudioClip LongBenoSound; 
    
     public Vector3 offset;

     public float Smoothness = 0.125f;

     private void Start(){
        player = FindObjectOfType<BeanosPlayer>();
     }
    


    private void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness);
        transform.position = smoothedPosition;


        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuAlpha1");
        }

        infoDrawer (player.MakeLongBenoSound);

        



    }

    private void infoDrawer(bool MakeLongBenoSound){
        if (MakeLongBenoSound == true){
            AudioSource.PlayClipAtPoint(LongBenoSound, transform.position);
            MakeLongBenoSound = false;
            
        }
    }

   

    







}
