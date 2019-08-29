using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private int i = 0;

    void Update()
    {
        if (DataScript.waypoints != null)
        {
            
            if (transform.position != DataScript.waypoints[i])
            {
                
                transform.position = Vector3.MoveTowards(transform.position, DataScript.waypoints[i], speed * Time.deltaTime);
               
            }
            else if(i<DataScript.waypoints.Count - 1)
                i++;

            Quaternion truckRotation = Quaternion.LookRotation(DataScript.waypoints[i] - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, truckRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        UIHandler uIHandler = FindObjectOfType(typeof(UIHandler)) as UIHandler;

        if (collision.gameObject.tag == "Obstacle")
        {
            uIHandler.GameOver();
        }
        else if(collision.gameObject.tag == "FinishLine")
        {
            uIHandler.LevelPassed();
        }
    }

    
}
