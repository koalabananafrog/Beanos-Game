using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HomingRocket : MonoBehaviour
{
    public float speed;
    public GameObject Beanos;
    
    public Transform Course;
    public float rotSpeed;
    public float maxAngle;
    public GameObject BOOM;
    [SerializeField] private AudioClip soundBoom;
    
    
    // Start is called before the first frame update
    
    private void Awake(){
        Beanos = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate(){
        
        transform.position = Vector3.MoveTowards(transform.position, Course.position, speed * Time.deltaTime);
        
        Quaternion rotTarget = Quaternion.LookRotation(Beanos.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, rotSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other){
        Instantiate(BOOM, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(soundBoom, Beanos.transform.position);
        Debug.Log("Penis");
        Destroy(gameObject);
        if(other.gameObject.layer == 11){
            Beanos.GetComponent<BeanosPlayer>().dieBeanos = true;
        }
    }

}
