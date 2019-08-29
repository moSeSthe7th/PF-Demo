using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
   
    private Transform truck;

    private void Start()
    {
        truck = GameObject.FindWithTag("Truck").GetComponent<Transform>();
    }

    void Update()
    {
        if(transform.position.y < 0) //|| (transform.position.x<truck.position.x && transform.position.z<truck.position.z))
        {
            Destroy(gameObject);
        }
    }
}
