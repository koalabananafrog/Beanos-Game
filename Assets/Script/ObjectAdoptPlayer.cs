using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAdoptPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == 11){
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision){
        if (collision.gameObject.layer == 11){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
