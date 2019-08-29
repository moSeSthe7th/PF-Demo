using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoPhysicsScript : MonoBehaviour
{
    public float overlapSphereRadius;
   
    public float explosionForce;
    public float explosionRadius;
    public float upwardsExplosionModifier;

    
    private void Update()
    {
        CreateExplosion();
    }

    void CreateExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, overlapSphereRadius);

        foreach (Collider nearbyObject in colliders)
        {
            float distance = (nearbyObject.gameObject.transform.position - transform.position).sqrMagnitude;

            Rigidbody rigidbody = nearbyObject.GetComponent<Rigidbody>();

            if (rigidbody != null && nearbyObject.gameObject.tag != "Truck" && distance != 0)
            {
                rigidbody.AddExplosionForce(explosionForce / distance, transform.position, explosionRadius, upwardsExplosionModifier / distance);
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            UIHandler uIHandler = FindObjectOfType(typeof(UIHandler)) as UIHandler;
            uIHandler.GameOver();
        }
    }
    
}
