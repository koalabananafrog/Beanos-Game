using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Audio;
using System;
using System.Timers; 

public class BeanosPlayer : MonoBehaviour
{
    private bool isLongBeanosTrue;
    private float LongBenoDuration = 5f;
    public bool BenosIsLong;
    private bool longBeanosTime;
    public float targetTime = 100.0f;
    private bool Dead;
    private bool touchingJumpAbleObj;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    private bool _ismoving;
    private float Leftturnspeed;
    private float Rightturnspeed;
    private float Speed;
    [SerializeField] private AudioSource LongBeno;
    public AudioSource jumpSound;
    private bool MakeNoise;
    private Vector3 Longbeanos;
    private Vector3 sneakingLongbeanos;
    private Vector3 beanosCurrentState;
    private Vector3 deadBeanos;
    private Vector3 Normalbeanos;
    private Vector3 Sneakingbeanos;
    private float Coins;
    private bool deathToBeanos;

    private bool isSneaking;
    [SerializeField] private GameObject RespawnMenu;
    private bool Ddown;
    private bool Adown;
    private bool beanosCanJump = true;
    private bool jumpkeywaspressed;
    private float horizontalinput;
    private Rigidbody rigidbodycomponent;
    // Start is called before the first frame update
    void Start()
    {
        
        Rightturnspeed = 120;
        
        Leftturnspeed = -120;
        
        rigidbodycomponent = GetComponent<Rigidbody>();
        
        Speed = 2;
        
        Longbeanos = new Vector3(2, 2.8f, 2);
        
        Sneakingbeanos = new Vector3(1, 0.6f, 1);
        
        Normalbeanos = new Vector3(1, 1, 1);
        
        deadBeanos = new Vector3(0.9f, 0.2f, 1);
        
        sneakingLongbeanos = new Vector3(2, 2.4f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Input control
        
 
        

       

        if(Dead){
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
        float tiltAroundZ = 0 * tiltAngle;
        float tiltAroundX = 0 * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltAroundX, -270, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        beanosCanJump = false;
       
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(transform.rotation.x + Rightturnspeed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(transform.rotation.x + Leftturnspeed, 0, 0) * Time.deltaTime);
        }

        beanosCurrentState = transform.localScale;

        if (Input.GetKey(KeyCode.S) && !isSneaking && !isLongBeanosTrue || Input.GetKey(KeyCode.DownArrow) && !isSneaking && !isLongBeanosTrue){
            // Start sneaking
            transform.localScale = Sneakingbeanos;
            Speed = 2.5f;
            isSneaking = true; 
        } 
   

        
        if (!Input.GetKey(KeyCode.S) && isSneaking || Input.GetKey(KeyCode.DownArrow) && isSneaking) {
            // Rise up
            transform.localScale = Normalbeanos;
            isSneaking = false; 
        }
       
        if (MakeNoise == true)
        {
           
        }
        
        
        
        if(deathToBeanos == true)
        {
            RespawnMenu.SetActive(true);
            Dead = true;
            transform.localScale = deadBeanos;
        }
        if(Dead){
            return;
        }




        horizontalinput = Input.GetAxis("Horizontal") * Speed;
        
        
        if (Input.GetKeyDown(KeyCode.Space) && beanosCanJump == true)
        {
            jumpkeywaspressed = true;
            beanosCanJump = false;
            ;
  

        }

        if (_ismoving == false)
        {
            return;
        }
        
            
        //if (Input.GetKeyDown(KeyCode.D))
        //{
           // Ddown = true;
        //}

  

        //if (Input.GetKeyDown(KeyCode.A))
        //{
            //Adown = true;
        //}

        if (isLongBeanosTrue == false){
            Debug.Log("it's false maaaaaan");
        }
        

    
        
 
 




    }
    private void FixedUpdate()
    {
        if (jumpkeywaspressed == true && !isSneaking)
        {
            rigidbodycomponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);

            jumpkeywaspressed = false;
            
        
        }
        rigidbodycomponent.velocity = new Vector3(horizontalinput, rigidbodycomponent.velocity.y, 0);

        



        
        

        
        //RotationCheck
       

    }
     

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            beanosCanJump = true;
        }

        if (collision.gameObject.layer == 6)
        {
            deathToBeanos = true;

           
        }







    }


    public static int LONGBEANOS = 8;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            Coins++;

        }

        //Poweruplongbeno
        
        if (other.gameObject.layer == LONGBEANOS && !isSneaking)
        {
            Debug.Log("HEJ!!!");
            
            Destroy(other.gameObject);
            
            transform.localScale = Longbeanos;
            
            MakeNoise = true;
            
            Speed = Speed ++;
            
            Rightturnspeed = Rightturnspeed + 30;
            
            Leftturnspeed = Leftturnspeed - 30;
            
            isLongBeanosTrue = true;

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 10000;
            aTimer.Elapsed += (object source, ElapsedEventArgs e) => {
                 
                 Debug.Log("1");
                isLongBeanosTrue = false;
                  Debug.Log("2");
                 transform.localScale = Normalbeanos;
                  Debug.Log("3");
                 Speed = Speed --;
                  Debug.Log("4");
                Rightturnspeed = Rightturnspeed - 30;
                   Debug.Log("5");
                Leftturnspeed = Leftturnspeed + 30;
                 Debug.Log("6");
                 
                 isLongBeanosTrue = false;

                 Debug.Log("Finished waiting");

                  aTimer.Dispose();
            };
            Debug.Log("Start waiting...");
            aTimer.Start();
        }       

        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            // transform.localScale = Faaaaaaastbeanos;
            MakeNoise = true;
            Speed = 4;
            Rightturnspeed = 10000;
            Leftturnspeed = -10000;

        }

        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
            // transform.localScale = Beanos;
            MakeNoise = true;
            Speed = 4;
            Rightturnspeed = 120;
            Leftturnspeed = -120;        
        }

    }
}