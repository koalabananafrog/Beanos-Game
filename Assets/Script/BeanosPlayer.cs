using System.Collections;
using System.Collections.Generic;
using UnityEngine.Search;
using UnityEngine;
using TMPro;
using Unity.Audio;
using System;
using System.Timers;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class BeanosPlayer : MonoBehaviour
{
    private bool exploJump;
    public CameraScript NewCamera;
    private bool executeBeanos;
    private bool beanosShallJump;
    public static Vector3 BeanosVelocity;
    private bool sneakBlocker;
    private bool stabilizing;
    private int beanosGrounds;
    private Vector3 FatBenobeanos;
    private float Jumppower = 350;
    public bool MakeLongBenoSound;
    [SerializeField] private GameObject Longbenopickupeffect; 
    public bool BenosIsLong;
    public float targetTime = 100.0f;
    private bool Dead;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    private float Leftturnspeed;
    private float Rightturnspeed;
    private float Speed;
    [SerializeField] private AudioClip LongBenoSound;
    [SerializeField] private AudioClip FatBenoSound;
    public AudioClip jumpSound;
    private Vector3 Longbeanos;
    private Vector3 deadBeanos;
    private Vector3 Normalbeanos;
    private Vector3 Sneakingbeanos;
    private float Coins;
    private bool sendDeathSpider;
    private bool sneaking;
    [SerializeField] private GameObject RespawnMenu;
    private bool beanosCanJump;
    private float horizontalinput;
    private Rigidbody rigidbodycomponent;
    private Camera MainCamera;
    public bool makeCollisionFalse;
    private bool dieBeanos;
    [SerializeField] private Transform spider;
    [SerializeField] private GameObject FatBenoFX;
    private bool AWPFORCE;
    [SerializeField] private AudioClip CoinSound;
    [SerializeField] private GameObject CoinEffect;
    [SerializeField] private float CameraAnglerY;
    [SerializeField] private float CameraAnglerZ;
    public FixedJoystick joystick;
    public JumpButtonS JumpButtonS;
    private bool heyDontSpamJump;
    private float jumpedInt;
    private float groundedInt = 0;
    private float possibleJump;
    private float one = 1;
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        Rightturnspeed = 140;
        Leftturnspeed = -140;
        rigidbodycomponent = GetComponent<Rigidbody>();
        Speed = 2;
        Longbeanos = new Vector3(2, 2.8f, 2);
        Sneakingbeanos = new Vector3(0.7f, 0.6f, 0.7f);
        Normalbeanos = new Vector3(1, 1, 1);
        deadBeanos = new Vector3(1.5f, 0.4f, 1.5f);
        FatBenobeanos = new Vector3(2, 1, 2.2f);
    }
    private bool joystickDown;
    private bool joystickUp;
    private bool theresPossibleJump;
    private bool jumped;
    private bool airborn;
    // Update is called once per frame
    void Update()
    {
        // Joystick vertical
        if(joystick.Vertical > 0.6){
            joystickUp = true;
        }
        else{
            joystickUp = false;
        }
        if(joystick.Vertical < -0.6){
            joystickDown = true;
        }
        else{
            joystickDown = false;
        }


        //Joystick JumpButton Detection
        if(JumpButtonS.buttonPressed){
            jumpButton = true;
        }else{
            jumpButton = false;
        }
        if(jumpButton){
            Debug.Log("?True");
        }else{
            Debug.Log("?False");
        }
        

        // Joystick Jump Spam Block
        if(!groundedBool){
            airborn = true;
        }
        if(groundedBool && airborn){
            jumped = false;
            airborn = false;
        }
        if(groundedBool && !jumped){
            theresPossibleJump = true;
        }
        else{
            theresPossibleJump = false;
        }
        if(theresPossibleJump){
            jumpSpamBlock = false;
        }
        else{
            jumpSpamBlock = true;
        }


        //Input controlcenter
        if(executeBeanos == true){
            // Destroy(gameObject);
            Debug.Log("sadasdawedfaf");
        }
        if(Dead){
            return;
        }


        // Stabilize
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || joystickUp){
            float tiltAroundZ = 0 * tiltAngle;
            float tiltAroundX = 0 * tiltAngle;
            Quaternion target = Quaternion.Euler(tiltAroundX, -270, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
            stabilizing = true;
        }
        else{
            stabilizing = false;
        }



        // Move right
        if (horizontalinput > 0.3f || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(transform.rotation.x + Rightturnspeed, 0, 0) * Time.deltaTime);
        }
        // Move left
        if (horizontalinput < -0.3f || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(transform.rotation.x + Leftturnspeed, 0, 0) * Time.deltaTime);
        }


        // Sneak down
        if ( joystickDown && !sneaking && !sneakBlocker) {
            transform.localScale = Sneakingbeanos;
            Speed = 3.5f;
            sneaking = true; 
        } 
        // Input.GetKey(KeyCode.S) && !sneaking && !sneakBlocker ||
        // Sneak up
        
        if (!joystickDown && sneaking){
            transform.localScale = Normalbeanos;
            Speed = 2.5f;
            sneaking = false; 
        }
        // !Input.GetKey(KeyCode.S) && sneaking || 

    //    || joystick.Vertical > -0.1 && sneaking
        // Death void detection
        if(dieBeanos == true)
        {
            RespawnMenu.SetActive(true);
            Dead = true;
            transform.localScale = deadBeanos;
            rigidbodycomponent.constraints = RigidbodyConstraints.FreezePosition;
        }
        if (sendDeathSpider == true){
            spider.gameObject.SetActive(true);
        }

       
        
        
        //private bool heyDontSpamJump;
        if (Input.GetKeyDown(KeyCode.Space) && beanosCanJump == true || jumpButton && beanosCanJump == true && !jumpSpamBlock)
        {      
             beanosShallJump = true;
             jumped = true;
        }

        // Checking if beanos is (allowed) to jump
        if (beanosGrounds > 0 && !sneaking && !stabilizing)
        {
            beanosCanJump = true;
        } 
        else{
            beanosCanJump = false;
        }

        BeanosVelocity = new Vector3(rigidbodycomponent.velocity.x, rigidbodycomponent.velocity.y, rigidbodycomponent.velocity.z);
       
       

    }
    
    private void FixedUpdate()
    {   
        
         

         if(Input.GetAxis("Horizontal") !=0){
            horizontalinput = Input.GetAxis("Horizontal") * Speed;
        }else{
            horizontalinput = joystick.Horizontal * Speed;
        }
        if(makeCollisionFalse == true){
            rigidbodycomponent.detectCollisions = false;
        }
        // jump Force Add
        if (beanosShallJump == true)
        {
            rigidbodycomponent.AddForce(Vector3.up * Jumppower * Time.deltaTime, ForceMode.VelocityChange);
            beanosShallJump = false;
            AudioSource.PlayClipAtPoint(jumpSound, MainCamera.transform.position);

            
            if(exploJump == true){
                Instantiate(FatBenoFX, transform.position + new Vector3(0, -1, 0), transform.rotation);
                AudioSource.PlayClipAtPoint(FatBenoSound, MainCamera.transform.position);
            }
        }
        rigidbodycomponent.velocity = new Vector3(horizontalinput, rigidbodycomponent.velocity.y, 0);

        if (AWPFORCE == true){
            rigidbodycomponent.AddForce(transform.up * 35);
        }
    }
    
    private bool jumpSpamBlock;
    private bool groundedBool;
    //COLLISION STATION!
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            
            Debug.Log(beanosGrounds);
            if(beanosGrounds == 0){
                groundedBool = true;
                Debug.Log("I DID IT");
            }
            beanosGrounds++;

        }

        if (collision.gameObject.layer == 6)
        {
            sendDeathSpider = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            beanosGrounds--;
            Debug.Log(beanosGrounds);
            jumpSpamBlock = true;
            if(beanosGrounds == 0){
                groundedBool = false;
                Debug.Log("I STILL DID IT");
            }
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
            AudioSource.PlayClipAtPoint(CoinSound, MainCamera.transform.position);
            Instantiate(CoinEffect, transform.position, transform.rotation);
            Debug.Log(Coins);
        }
        if (other.gameObject.layer == 13){
            dieBeanos = true;
        }
        // if (other.gameObject.layer == 12){
        //     FinishSceneCameraFunction();
        // }

        // PWU Example

        //if(other.gameObject is PowerUp) {
        //    PowerUp powerUp = (PowerUp) other.gameObject;
        //    powerUp.DoPowerUp();
        //}

        // Power-up longbeno
        if (other.gameObject.layer == LONGBEANOS && !sneaking)
        {
            StartCoroutine(DoLongBeanos());
            Destroy(other.gameObject);
        }       
        // Power-up fatbeno
        if (other.gameObject.layer == FatBeno && !sneaking)
        {
            Destroy(other.gameObject);
            StartCoroutine(DoFatBeno());
        }   
        if (other.gameObject.tag == "WATERPULSE"){
            AWPFORCE = true;
            NewCamera.Smoothness = 0.2f;
        }
        if(other.gameObject.tag == "CameraAngler"){
            NewCamera.offset.z = NewCamera.offset.z + other.gameObject.GetComponent<FloatValue>().Value;
        }  
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "WATERPULSE"){
            AWPFORCE = false;
            NewCamera.Smoothness = 0.125f;
        }  
        if(other.gameObject.tag == "CameraAngler"){
         NewCamera.offset.z = NewCamera.offset.z - other.gameObject.GetComponent<FloatValue>().Value; 
        }
    }

    int beanosLongCount = 0;
   
   IEnumerator DoLongBeanos()  //  <-  its a standalone method
    {
        LongBeanos();
        beanosLongCount = 1;
        yield return new WaitForSeconds(15);
        beanosLongCount -= 1;
        if(beanosLongCount == 0) {
            ReverseLongBeanos();
        }
    }


    private void LongBeanos()
    {
        Instantiate(Longbenopickupeffect, transform.position, transform.rotation);
        NewCamera.offset = NewCamera.offset + new Vector3(0, 0, -2);
        NewCamera.Smoothness = 0.2f;
        AudioSource.PlayClipAtPoint(LongBenoSound, MainCamera.transform.position);
        transform.localScale = Longbeanos;
        Speed = Speed++ ;
        Rightturnspeed = Rightturnspeed + 30;
        Leftturnspeed = Leftturnspeed - 30;
        sneakBlocker = true;
        Jumppower = Jumppower * 1.5f;   
    }

    private void ReverseLongBeanos()
    {
        sneakBlocker = false;
        NewCamera.offset = NewCamera.offset + new Vector3(0, 0, 1);
        NewCamera.Smoothness = 0.125f;
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
        yield return new WaitForSeconds(20);
        FatBenoCount -= 1;
        if(FatBenoCount == 0) {
            UnsetFatBeno();
        }
    }


    private void SetFatBeno()
    {
        Instantiate(FatBenoFX, transform.position, transform.rotation);
        NewCamera.offset = NewCamera.offset + new Vector3(0, 0, -10);
        AudioSource.PlayClipAtPoint(FatBenoSound, MainCamera.transform.position);
        transform.localScale = FatBenobeanos;
        Speed = Speed + 2;
        Rightturnspeed = Rightturnspeed + 10;
        Leftturnspeed = Leftturnspeed - 10;
        sneakBlocker = true;
        Jumppower = Jumppower * 3;
        exploJump = true;
        NewCamera.Smoothness = 0.2f;

    }

    private void UnsetFatBeno()
    {
        sneakBlocker = false;
        transform.localScale = Normalbeanos;
        Speed = Speed - 2;
        Rightturnspeed = Rightturnspeed -10;
        Leftturnspeed = Rightturnspeed +10;
        sneakBlocker = false;
        Jumppower = Jumppower / 3;
        NewCamera.offset = NewCamera.offset + new Vector3(0, 0, 10);   
        exploJump = false;
        NewCamera.Smoothness = 0.125f;
    }   
    private bool jumpButton;
    // public void JumpButton(){
    //     jumpButton = true;
    // }

    // private void FinishSceneCameraFunction(){
    //     NewCamera.offset = NewCamera.offset + new Vector3(0, 0 , -10);
    //     NewCamera.Smoothness = NewCamera.Smoothness + 10;
    //     Normalbeanos = new Vector3(0, 0, 0);
    // }
    








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