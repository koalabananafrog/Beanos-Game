using System.Collections;
using System.Collections.Generic;
using UnityEngine.Search;
using UnityEngine;
using TMPro;
using Unity.Audio;
using System;
using System.Timers;
//using PowerUps;

public enum Command {
    moveForward,
    moveBackward,
    jump,
} 

public class BeanosPlayer : MonoBehaviour
{
    public CameraScript NewCamera; 
    private bool beanosShallJump;
    private bool sneakBlocker;
    private bool JumpRequestAllowed;
    private bool stabilizing;
    private bool JumpRequest;
    private bool beanosIsGrounded;
    private bool beanosCouldJumpBefore;
    private Vector3 FatBenobeanos;
    private float Jumppower = 5;
    public bool MakeLongBenoSound;
    public ScriptableObject CameraScript;
    [SerializeField] private GameObject Longbenopickupeffect; 
    private float LongBenoDuration = 5f;
    public bool BenosIsLong;
    private bool longBeanosTime;
    public float targetTime = 100.0f;
    private bool Dead;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    private bool _ismoving;
    private float Leftturnspeed;
    private float Rightturnspeed;
    private float Speed;
    [SerializeField] private AudioClip LongBenoSound;
    public AudioClip jumpSound;
    private bool MakeNoise;
    private Vector3 Longbeanos;
    private Vector3 sneakingLongbeanos;
    private Vector3 deadBeanos;
    private Vector3 Normalbeanos;
    private Vector3 Sneakingbeanos;
    private float Coins;
    private bool deathToBeanos;
    private bool sneaking;
    [SerializeField] private GameObject RespawnMenu;
    private bool Ddown;
    private bool Adown;
    private bool beanosCanJump = true;
    private bool jumpKeyWasPressed;
    private float horizontalinput;
    private Rigidbody rigidbodycomponent;
    // Start is called before the first frame update
    private Camera MainCamera;
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        Rightturnspeed = 120;
        Leftturnspeed = -120;
        rigidbodycomponent = GetComponent<Rigidbody>();
        Speed = 2;
        Longbeanos = new Vector3(2, 2.8f, 2);
        Sneakingbeanos = new Vector3(1, 0.6f, 1);
        Normalbeanos = new Vector3(1, 1, 1);
        deadBeanos = new Vector3(0.9f, 0.2f, 1);
        sneakingLongbeanos = new Vector3(2, 2.4f, 2);
        FatBenobeanos = new Vector3(2, 1, 2.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Input controlcenter
        
        if(Dead){
            return;
        }


        // Stabilize
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            float tiltAroundZ = 0 * tiltAngle;
            float tiltAroundX = 0 * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, -270, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
            stabilizing = true;
        }



        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(transform.rotation.x + Rightturnspeed, 0, 0) * Time.deltaTime);
        }
        // Move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(transform.rotation.x + Leftturnspeed, 0, 0) * Time.deltaTime);
        }


        // Sneak down
        if (Input.GetKey(KeyCode.S) && !sneaking && !sneakBlocker || Input.GetKey(KeyCode.DownArrow) && !sneaking && !sneakBlocker){
            transform.localScale = Sneakingbeanos;
            Speed = 2.5f;
            sneaking = true; 
        } 
        // Sneak up
        if (!Input.GetKey(KeyCode.S) && sneaking || Input.GetKey(KeyCode.DownArrow) && sneaking) {
            transform.localScale = Normalbeanos;
            sneaking = false; 
        }

       
        // Death void detection
        if(deathToBeanos == true)
        {
            RespawnMenu.SetActive(true);
            Dead = true;
            transform.localScale = deadBeanos;
        }

        horizontalinput = Input.GetAxis("Horizontal") * Speed;
        
        if (Input.GetKeyDown(KeyCode.Space) && beanosCanJump == true)
        {      
             beanosShallJump = true;
             Debug.Log("HOHO");
        }

        // Checking if beanos is (allowed) to jump
        if (beanosIsGrounded == true)// && !sneaking || !stabilizing)
        {
            beanosCanJump = true;
            Debug.Log("HA");
        } 
        if (beanosIsGrounded == false)// && !sneaking || !stabilizing)
        {
            beanosCanJump = false;
            Debug.Log("HA");
        }

        if(beanosCanJump == false){
            Debug.Log("heynot");
        }
        if(beanosCanJump == true){
            Debug.Log("hey");
        }
        if(beanosIsGrounded == false){
            Debug.Log("False");
        } 
        if(beanosIsGrounded == true){
            Debug.Log("True");
        }

    }
    
    
    private void FixedUpdate()
    {
        if (beanosShallJump == true)
        {
            rigidbodycomponent.AddForce(Vector3.up * Jumppower, ForceMode.VelocityChange);
            Debug.Log("!!!");
            beanosShallJump = false;
        }
        rigidbodycomponent.velocity = new Vector3(horizontalinput, rigidbodycomponent.velocity.y, 0);
    }
    
    
    
    //COLLISION STATION!
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            beanosIsGrounded = true;
            Debug.Log("HAHAH");
        }

        if (collision.gameObject.layer == 6)
        {
            deathToBeanos = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            beanosIsGrounded = false;
            Debug.Log("Exit!");
        }
    }


    
    
    
    
    public static int LONGBEANOS = 8;
    public static int COIN = 7;
    public static int FatBeno = 9;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == COIN)
        {
            Destroy(other.gameObject);
            Coins++;
            Debug.Log(Coins);
        }

        // PWU Example

        //if(other.gameObject is PowerUp) {
        //    PowerUp powerUp = (PowerUp) other.gameObject;
        //    powerUp.DoPowerUp();
        //}

        // Power-up longbeno
        if (other.gameObject.layer == LONGBEANOS && !sneaking)
        {
            Destroy(other.gameObject);
            StartCoroutine(DoLongBeanos());
        }       
        // Power-up fatbeno
        if (other.gameObject.layer == FatBeno && !sneaking)
        {
            Destroy(other.gameObject);
            StartCoroutine(DoFatBeno());
        }     




    }

    int beanosLongCount = 0;
   
   IEnumerator DoLongBeanos()  //  <-  its a standalone method
    {
        NewCamera.offset = new Vector3(1, 1, -16.5f);
        Debug.Log("Long");
        LongBeanos();
        beanosLongCount = 1;
        yield return new WaitForSeconds(20);
        beanosLongCount -= 1;
        if(beanosLongCount == 0) {
            ReverseLongBeanos();
        }
        Debug.Log("Not long");
    }


    private void LongBeanos()
    {
        Instantiate(Longbenopickupeffect, transform.position, transform.rotation);

        // Debug.Log(MainCamera);
        AudioSource.PlayClipAtPoint(LongBenoSound, MainCamera.transform.position);
        transform.localScale = Longbeanos;
        MakeNoise = true;
        Speed = Speed ++;
        Rightturnspeed = Rightturnspeed + 30;
        Leftturnspeed = Leftturnspeed - 30;
        sneakBlocker = true;
        Jumppower = Jumppower * 1.5f;   
    }

    private void ReverseLongBeanos()
    {
        sneakBlocker = false;
        transform.localScale = Normalbeanos;
        Speed = Speed --;
        Rightturnspeed = Rightturnspeed - 30;
        Leftturnspeed = Leftturnspeed + 30;
        sneakBlocker = false;
        Jumppower = Jumppower / 1.5f;   
    }

    

    
    
     







    int FatBenoCount = 0;

   IEnumerator DoFatBeno()  //  <-  its a standalone method
    {
        SetFatBeno();
        FatBenoCount = 1;
        yield return new WaitForSeconds(15);
        FatBenoCount -= 1;
        if(FatBenoCount == 0) {
            UnsetFatBeno();
        }
    }


    private void SetFatBeno()
    {
        transform.localScale = FatBenobeanos;
        Speed = Speed + 2;
        Rightturnspeed = Rightturnspeed + 10;
        Leftturnspeed = Leftturnspeed - 10;
        sneakBlocker = true;
        Jumppower = Jumppower * 1.5F;   
    }

    private void UnsetFatBeno()
    {
        sneakBlocker = false;
        transform.localScale = Normalbeanos;
        Speed = Speed - 2;
        Rightturnspeed = Rightturnspeed -10;
        Leftturnspeed = Rightturnspeed +10;
        sneakBlocker = false;
        Jumppower = Jumppower / 1.5f;   
    }   
    








// PWU Example


//      int _POWERUPNAME_Count = 0;

//    IEnumerator Do_POWERUPNAME()  //  <-  its a standalone method
//     {
//         Set_POWERUPNAME_();
//         _POWERUPNAME_Count = 1;
//         yield return new WaitForSeconds(?);
//         _POWERUPNAME_Count -= 1;
//         if(_POWERUPNAME_Count == 0) {
//             Unset_POWERUPNAME_();
//         }
//     }


//     private void Set_POWERUPNAME_()
//     {
//         Instantiate(_POWERUPNAME_upeffect, transform.position, transform.rotation);
//         AudioSource.PlayClipAtPoint(_POWERUPNAME_Sound, MainCamera.transform.position);
//         transform.localScale = _POWERUPNAME_beanos;
//         Speed = Speed + ?;
//         Rightturnspeed = Rightturnspeed + ?;
//         Leftturnspeed = Leftturnspeed - ?;
//         sneakBlocker = _TRUE OR FALSE_;
//         Jumppower = Jumppower * ?;   
//     }

//     private void Unset_POWERUPNAME_()
//     {
//         sneakBlocker = false;
//         transform.localScale = Normalbeanos;
//         Speed = Speed ?reverse?;
//         Rightturnspeed = Rightturnspeed ?reverse?;
//         Leftturnspeed = Leftturnspeed ?reverse?;
//         sneakBlocker = false;
//         Jumppower = Jumppower ?reverse?;   
//     }

    







}