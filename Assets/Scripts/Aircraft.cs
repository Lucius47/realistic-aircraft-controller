using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    [SerializeField] float enginePower;
    [SerializeField] float stallVelocity;



    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.inertiaTensorRotation = Quaternion.identity;
        rb.centerOfMass = Vector3.zero;

    }

    public float EnginePower
    {
        get { return enginePower; }
    }

    public float StallVelocity
    {
        get { return stallVelocity; }
    }

}
