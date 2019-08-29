using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform truck;
    public Vector3 offset;
    public float cameraMoveSpeed;

    private void FixedUpdate()
    {
        //Vector3 dummyPos = truck.position + offset;
        //Vector3 cameraPos = Vector3.Lerp(transform.position, dummyPos, cameraMoveSpeed * Time.deltaTime);
        //transform.position = cameraPos;


        //transform.LookAt(truck);
        

    }
}
