using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockParticleScript : MonoBehaviour {

    public float Force = 50f;
    private void Awake()
    {
        Destroy(gameObject, 10f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Force, transform.position, 5f);
            }
        }
    }
}
