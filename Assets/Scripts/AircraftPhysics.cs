using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftPhysics : MonoBehaviour
{
    Aircraft aircraft;
    Rigidbody rb;
    Vector3 velocity;
    float gravity = 98.1f;

    float engineThrustPercentage;
    float aileronExtension;
    float elevatorExtension;
    float rudderExtension;

    float lastUpVelocity;
    float lastForwardVelocity;
    float accelerationY;
    float accelerationZ;
    


    void Start()
    {
        aircraft = GetComponent<Aircraft>();
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {

        ApplyEngineThrust();
        ApplyDrag();
        ApplyGravity();
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
        rb.AddForce(transform.forward * (engineThrustPercentage * aircraft.EnginePower + 0));
        //Debug.DrawRay(aircraft.EngineThrustPosition, transform.forward * engineThrustPercentage * 10, Color.red);
    }

    void ApplyDrag()
    {
        rb.AddForce(-transform.forward * Mathf.Pow(velocity.z, 2) * 0.001f);
    }

    void ApplyGravity()
    {
        rb.AddForce((new Vector3(0, -1, 0) * gravity * rb.mass));
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
        lift = Mathf.Clamp(lift, 2, gravity * rb.mass);
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
    public float ForwardAcc
    {
        get { return accelerationZ; }
    }
    public float UpwardAcc
    {
        get { return accelerationY; }
    }

    public float EngineThrustPercentage
    {
        get { return engineThrustPercentage; }
        set { engineThrustPercentage = value/100; }
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
