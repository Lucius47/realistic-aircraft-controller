using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aircraft : MonoBehaviour
{
    [SerializeField] float massOfAircraft; //in kg
    [SerializeField] float enginePower;
    [SerializeField] float wingArea; //area of one wing
    [SerializeField] float stallVelocity;

    [SerializeField] Transform engineTransform;
    [SerializeField] Transform leftWingTransform;
    [SerializeField] Transform rightWingTransform;
    [SerializeField] Transform elevatorLiftPosition;
    [SerializeField] Transform rudderForcePosition;
    [SerializeField] Transform leftAileronForcePosition;
    [SerializeField] Transform rightAileronForcePosition;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.inertiaTensorRotation = Quaternion.identity;
        rb.centerOfMass = Vector3.zero;
        rb.mass = massOfAircraft;

    }

    public Vector3 LeftWingLiftPosition
    {
        get { return leftWingTransform.position; }
    }

    public Vector3 RightWingLiftPosition
    {
        get { return rightWingTransform.position; }
    }

    public Vector3 EngineThrustPosition
    {
        get { return engineTransform.position; }
    }

    public Vector3 ElevatorLiftPosition
    {
        get { return elevatorLiftPosition.position; }
    }

    public Vector3 RudderForcePosition
    {
        get { return rudderForcePosition.position; }
    }

    public Vector3 LeftAileronForcePosition
    {
        get { return leftAileronForcePosition.position;}
    }

    public Vector3 RightAileronForcePosition
    {
        get { return rightAileronForcePosition.position; }
    }

    public float EnginePower
    {
        get { return enginePower; }
    }

    public float WingArea
    {
        get { return wingArea; }
    }

    public float StallVelocity
    {
        get { return stallVelocity; }
    }

}
