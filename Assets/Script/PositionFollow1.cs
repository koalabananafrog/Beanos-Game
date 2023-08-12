using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollow1: MonoBehaviour
{
    [SerializeField] private Transform PositionHolder;
    [SerializeField] private bool freezeAllPosExeptX = false;
    [SerializeField] private bool followWithOffset = false;
    
    private Vector3 position;

    private void FixedUpdate()
    {   
        if(followWithOffset == true){
            var offset = transform.position - PositionHolder.transform.position;
            position = PositionHolder.transform.position + offset;
            transform.position = position;
        } else if(freezeAllPosExeptX == false){
                transform.position = PositionHolder.transform.position;
                }
                else{
                    transform.position = position;
                    position = new Vector3(PositionHolder.transform.position.x, PositionHolder.transform.position.y, PositionHolder.transform.position.z + 5);
                }
    }
}
