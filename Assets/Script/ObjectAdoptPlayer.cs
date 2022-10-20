using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAdoptPlayer : MonoBehaviour
{
    [SerializeField] private Transform WantedParent;
    private Vector3 lastPos;
    private bool adopt;
    private Vector3 posDiff;
    
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == 11){
            adopt = true;
        }
    }

    private void OnCollisionExit(Collision collision){
        if (collision.gameObject.layer == 11){
            collision.gameObject.transform.SetParent(null);
        }
    }
    

    void Update(){
       
        posDiff.Equals(transform.position - lastPos);
        
        lastPos = transform.position;
        Debug.Log(posDiff);
        Debug.Log(lastPos);
        Debug.Log(transform.position);
    }
    private void FixedUpdate(){
        
    }
}
