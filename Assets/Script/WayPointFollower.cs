using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float normalSpeed = 1;
    [SerializeField] private float fastSpeed = 10;
    private float currentSpeed;
    private int desiredWayPointIndex = 0;
    [SerializeField] private bool FaceWaiponts = false;
    [SerializeField] private bool ChangeSpeed = false;
    [SerializeField] private bool loop = true;
    [SerializeField] private bool fastReturn = false;
    [SerializeField] private bool stayOnEnds = false;
    [SerializeField] private float stayTime = 5;


    void Start(){
        currentSpeed = normalSpeed;
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, WayPoints[desiredWayPointIndex].transform.position) < 0.1f){
            if(loop){
                if(WayPoints.Length - 1 == desiredWayPointIndex){
                    desiredWayPointIndex = 0;
                } else {
                    desiredWayPointIndex++;
                }
            } else {
                if(WayPoints.Length - 1 == desiredWayPointIndex){
                } else {
                    desiredWayPointIndex++;
                }
            }
        }

        

        if (FaceWaiponts){
            transform.LookAt(WayPoints[desiredWayPointIndex].transform);
        }

        if (ChangeSpeed){
            if (desiredWayPointIndex%2==0){
                currentSpeed = fastSpeed;
            }
            else{
                currentSpeed = normalSpeed;
            }
        }

        if(fastReturn){
            if(desiredWayPointIndex == WayPoints.Length - 1){
                currentSpeed = fastSpeed;
            }
            if(desiredWayPointIndex == 0){
                currentSpeed = normalSpeed;
            }
        }
        
        if(stayOnEnds){
            if(desiredWayPointIndex == WayPoints.Length - 1){
                StartCoroutine(WaitNow());
            }
            if(desiredWayPointIndex == 0){
                StartCoroutine(WaitNow());
            }
        }
    }

    private void FixedUpdate(){
        
        transform.position = Vector3.MoveTowards(transform.position, WayPoints[desiredWayPointIndex].transform.position, currentSpeed * Time.deltaTime);
        
    }

    IEnumerator WaitNow(){
        currentSpeed = 0;
        yield return new WaitForSeconds(5);
        currentSpeed = normalSpeed;
    }
    
}
