using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float speed = 1;
    [SerializeField] private float fastSpeed = 10;
    private int desiredWayPointIndex = 0;
    [SerializeField] private bool FaceWaiponts = false;
    [SerializeField] private bool ChangeSpeed = false;
    [SerializeField] private bool loop = true;

    
    void Update()
    {
        if (Vector3.Distance(transform.position, WayPoints[desiredWayPointIndex].transform.position) < 0.1f){
            if (WayPoints.Length != desiredWayPointIndex){
                desiredWayPointIndex++;
            }
            if (WayPoints.Length == desiredWayPointIndex && loop){
                desiredWayPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, WayPoints[desiredWayPointIndex].transform.position, speed * Time.deltaTime);

        if (FaceWaiponts){
            transform.LookAt(WayPoints[desiredWayPointIndex].transform);
        }

        if (ChangeSpeed){
            if (desiredWayPointIndex%2==0){
                speed = fastSpeed;
            }
            else{
                return;
            }
        }
    }
}
