using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arena")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<SphereCollider>());
        }
    }
}
