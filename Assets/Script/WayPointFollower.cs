using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private float speed = 1;
    private int desiredWayPointIndex = 0;
    void Update()
    {
        if (Vector3.Distance(transform.position, WayPoints[desiredWayPointIndex].transform.position) < 0.1f){
            desiredWayPointIndex++;
            if (WayPoints.Length == desiredWayPointIndex){
                desiredWayPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, WayPoints[desiredWayPointIndex].transform.position, speed * Time.deltaTime);
    }
}
