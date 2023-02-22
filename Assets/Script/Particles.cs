using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private Transform posHolder;
    private Vector3 offset;
    void Start(){
        offset = (posHolder.transform.position - transform.position) * -1;
    }
    private void FixedUpdate(){
        transform.position = new Vector3
     }
}
