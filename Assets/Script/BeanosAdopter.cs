using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanosAdopter : MonoBehaviour
{
    [SerializeField] private Transform PositionFollower;
    [SerializeField] private Transform PositionHolder;
    [SerializeField] private Transform RotationHolder;

    private void FixedUpdate()
    {
        PositionFollower.position = PositionHolder.position;
        PositionFollower.rotation = RotationHolder.rotation;
    }


}
