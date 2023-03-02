using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private Transform posHolder;
    private Vector3 offset;
    private Vector3 posHolderVector;
    void Start(){
        offset = (posHolderVector - transform.position) * -1;
        Debug.Log(offset + "offset");
        Debug.Log(posHolderVector + "posHolder");
    }
    private void FixedUpdate(){
        posHolderVector = posHolder.transform.position;
        var iWantPos = posHolderVector + offset;
        transform.position = new Vector3(iWantPos.x, transform.position.y, transform.position.z);
    }
}
