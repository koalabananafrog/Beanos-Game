using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezozShoot : MonoBehaviour
{
    public GameObject Mouth;
    public GameObject Aim;
    public GameObject BezozRocket;
    [SerializeField] private AudioClip Showsh;
    
    public void OnCollisionEnter(Collision other){
        if(other.gameObject.layer == 11){
            Instantiate(BezozRocket, Mouth.transform.position, Aim.transform.rotation);
            AudioSource.PlayClipAtPoint(Showsh, Mouth.transform.position);
        }
    }
}
