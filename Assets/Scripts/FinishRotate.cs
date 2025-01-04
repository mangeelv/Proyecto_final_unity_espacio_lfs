using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRotate : MonoBehaviour
{
    public float rotationSpeed = 0.1f; // Variable to control rotation speed

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}
