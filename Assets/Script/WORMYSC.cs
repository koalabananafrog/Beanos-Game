using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WORMYSC : MonoBehaviour
{
    [SerializeField] private GameObject WORMY;
    [SerializeField] private Transform Pos;
    [SerializeField] private Quaternion Rot;
    private void OnCollisionEnter(Collider other){
        if(other.gameObject.layer == 11){
            Instantiate(WORMY, Pos.position, Rot);
        }
    }
}
