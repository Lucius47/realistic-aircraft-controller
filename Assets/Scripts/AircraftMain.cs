using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMain : MonoBehaviour
{
    Aircraft aircraft;
    Rigidbody rb;
    Vector3 velocity;
    float lastUpVelocity;
    float lastForwardVelocity;
    float accelerationY;
    float accelerationZ;
    float engineThrustPercentage;

    float flapExtension;
    float aileronExtension;
    float elevatorExtension;
    float rudderExtension;


    void Start()
    {
        aircraft = GetComponent<Aircraft>();
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {

        ApplyEngineThrust();
        ApplyWingsLift();
        ApplyElevatorForce();
        ApplyRudderForce();
        ApplyAileronsForce();


        velocity = transform.InverseTransformDirection(rb.velocity);
        accelerationY = (velocity.y - lastUpVelocity) / Time.fixedDeltaTime;
        lastUpVelocity = velocity.y;
        accelerationZ = (velocity.z - lastForwardVelocity) / Time.fixedDeltaTime;
        lastForwardVelocity = velocity.z;

    }

    void ApplyEngineThrust()
    {
        rb.AddForce(transform.forward * engineThrustPercentage * aircraft.EnginePower);
        //Debug.DrawRay(aircraft.EngineThrustPosition, transform.forward * engineThrustPercentage * 10, Color.red);
    }

    void ApplyWingsLift()
    {
        rb.AddForce((new Vector3(0, 1, 0) * CalculateWingsLift()));
    }

    void ApplyElevatorForce()
    {
        rb.AddTorque(transform.right * elevatorExtension * 100);
    }

    void ApplyRudderForce()
    {
        rb.AddTorque(transform.up * rudderExtension * 100);
    }

    void ApplyAileronsForce()
    {
        rb.AddTorque(transform.forward * -aileronExtension * 100);
    }

    float CalculateWingsLift()
    {
        float lift = velocity.z;
        lift = Mathf.Clamp(lift, 2, 9.82f * rb.mass);
        return lift;
    }

    public float ForwardVelocity
    {
        get { return velocity.z; }
    }

    public float UpwardVelocity
    {
        get { return velocity.y; }
    }

    public float UpwardAcc
    {
        get { return accelerationY; }
    }

    public float ForwardAcc
    {
        get { return accelerationZ; }
    }

    public float EngineThrustPercentage
    {
        get { return engineThrustPercentage; }
        set { engineThrustPercentage = value/100; }
    }

    public float FlapExtension
    {
        get { return flapExtension; }
        set { flapExtension = value; }
    }

    public float ElevatorExtension
    {
        get { return elevatorExtension; }
        set { elevatorExtension = value; }
    }

    public float RudderExtension
    {
        get { return rudderExtension; }
        set { rudderExtension = value; }
    }

    public float AileronExtension
    {
        get { return aileronExtension;}
        set { aileronExtension = value; }
    }

}
