using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky1 : MonoBehaviour
{
    public int rotateSpeed = 2;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
