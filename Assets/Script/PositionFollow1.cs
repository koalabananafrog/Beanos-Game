using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollow1 : MonoBehaviour
{
    [SerializeField] private Transform PositionHolder;

    private void FixedUpdate()
    {
        transform.position = PositionHolder.transform.position;
    }
}
