using System.Collections;
using System.Collections.Generic;
using UnityEngine.Search;
using UnityEngine;
using TMPro;
using Unity.Audio;
using System;
using System.Timers; 

public class BeanosPlayer : MonoBehaviour
{
    private bool Sneakblocker;
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

        if (Input.GetKey(KeyCode.S) && !isSneaking && !Sneakblocker || Input.GetKey(KeyCode.DownArrow) && !isSneaking && !Sneakblocker){
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
        }

        if (_ismoving == false)
        {
            return;
        }
        
        if (Sneakblocker == false){
            Debug.Log("it's false maaaaaan");
        }

       
    }
    
    
    private void FixedUpdate()
    {
        if (jumpkeywaspressed == true && !isSneaking)
        {
            rigidbodycomponent.AddForce(Vector3.up * Jumppower, ForceMode.VelocityChange);

            jumpkeywaspressed = false;
        }
        rigidbodycomponent.velocity = new Vector3(horizontalinput, rigidbodycomponent.velocity.y, 0);
    }
    
    
    
    //COLLISION STATION!
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
    public static int COIN = 7;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == COIN)
        {
            Destroy(other.gameObject);
            Coins++;
            Debug.Log(Coins);
        }

        //Poweruplongbeno
        if (other.gameObject.layer == LONGBEANOS && !isSneaking)
        {
            Destroy(other.gameObject);
            StartCoroutine(DoLongBeanos());
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

    int beanosLongCount = 0;

   IEnumerator DoLongBeanos()  //  <-  its a standalone method
    {
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

        Debug.Log(MainCamera);
        AudioSource.PlayClipAtPoint(LongBenoSound, MainCamera.transform.position);
        transform.localScale = Longbeanos;
        MakeNoise = true;
        Speed = Speed ++;
        Rightturnspeed = Rightturnspeed + 30;
        Leftturnspeed = Leftturnspeed - 30;
        Sneakblocker = true;
        Jumppower = Jumppower * 1.5f;   
    }

    private void ReverseLongBeanos()
    {
        Sneakblocker = false;
        transform.localScale = Normalbeanos;
        Speed = Speed --;
        Rightturnspeed = Rightturnspeed - 30;
        Leftturnspeed = Leftturnspeed + 30;
        Sneakblocker = false;
        Jumppower = Jumppower / 1.5f;   
    }

    
    // public static int _POWERUPNAME_ = ?;
    
    
    //  if (other.gameObject.layer == _POWERUPNAME && !isSneaking)
    //     {
    //         Destroy(other.gameObject);
    //         StartCoroutine(Do_POWERUPNAME_());
    //     }     

//      int beanosLongCount = 0;

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
//         Sneakblocker = _TRUE OR FALSE_;
//         Jumppower = Jumppower * ?;   
//     }

//     private void Unset_POWERUPNAME_()
//     {
//         Sneakblocker = false;
//         transform.localScale = Normalbeanos;
//         Speed = Speed ?reverse?;
//         Rightturnspeed = Rightturnspeed ?reverse?;
//         Leftturnspeed = Leftturnspeed ?reverse?;
//         Sneakblocker = false;
//         Jumppower = Jumppower ?reverse?;   
//     }  







}