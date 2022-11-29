using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollow1 : MonoBehaviour
{
    [SerializeField] private Transform PositionHolder;
    [SerializeField] private bool freezeAllPosExeptX = false;
    private Vector3 position;

    private void FixedUpdate()
    {
        if(freezeAllPosExeptX == false){
            transform.position = PositionHolder.transform.position;
        }
        else{
            transform.position = position;
            position = new Vector3(PositionHolder.transform.position.x, PositionHolder.transform.position.y, PositionHolder.transform.position.z + 5);
        }
    }
}
