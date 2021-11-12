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
    float leftAileronExtension;
    float rightAileronExtension;


    void Start()
    {
        aircraft = GetComponent<Aircraft>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ApplyEngineThrust();
        velocity = transform.InverseTransformDirection(rb.velocity);
        accelerationY = (velocity.y - lastUpVelocity) / Time.fixedDeltaTime;
        lastUpVelocity = velocity.y;

        accelerationZ = (velocity.z - lastForwardVelocity) / Time.fixedDeltaTime;
        lastForwardVelocity = velocity.z;

        ApplyLeftWingLift();
        ApplyRightWingLift();
        ApplyElevatorForce();
        ApplyRudderForce();
        ApplyLeftAileronForce();
        ApplyRightAileronForce();
    }

    void ApplyEngineThrust()
    {
        rb.AddForceAtPosition(transform.forward * engineThrustPercentage * aircraft.EnginePower * 50, aircraft.EngineThrustPosition);
        Debug.DrawRay(aircraft.EngineThrustPosition, transform.forward * engineThrustPercentage * 10, Color.red);
        print(engineThrustPercentage * aircraft.EnginePower);
    }

    void ApplyLeftWingLift()
    {
        rb.AddForceAtPosition((new Vector3(0, 1, 0) * CalculateWingsLift() / 2), aircraft.LeftWingLiftPosition);
        Debug.DrawRay(aircraft.LeftWingLiftPosition, new Vector3(0, 1, 0) * 5 / 2, Color.red);
    }

    void ApplyRightWingLift()
    {
        rb.AddForceAtPosition((new Vector3(0, 1, 0) * CalculateWingsLift() / 2), aircraft.RightWingLiftPosition);
        Debug.DrawRay(aircraft.RightWingLiftPosition, new Vector3(0, 1, 0) * 5 / 2, Color.red);
    }

    void ApplyElevatorForce()
    {
        rb.AddForceAtPosition(transform.up * elevatorExtension, aircraft.ElevatorLiftPosition);
        Debug.DrawRay(aircraft.ElevatorLiftPosition, transform.up * 10 * elevatorExtension, Color.red);
    }

    void ApplyRudderForce()
    {
        rb.AddForceAtPosition(-transform.right * rudderExtension, aircraft.RudderForcePosition);
        Debug.DrawRay(aircraft.RudderForcePosition, -transform.right * 10 * rudderExtension, Color.red);
    }

    void ApplyLeftAileronForce()
    {
        rb.AddForceAtPosition(transform.up * leftAileronExtension, aircraft.LeftAileronForcePosition);
        Debug.DrawRay(aircraft.LeftAileronForcePosition, transform.up * 10 * leftAileronExtension, Color.red);
    }

    void ApplyRightAileronForce()
    {
        rb.AddForceAtPosition(transform.up * rightAileronExtension, aircraft.RightAileronForcePosition);
        Debug.DrawRay(aircraft.RightAileronForcePosition, transform.up * 10 * rightAileronExtension, Color.red);
    }

    float CalculateWingsLift()
    {
        float areaFacingWindStream = (aircraft.WingArea * -transform.rotation.x) + 0.1f; //AoA
        //return 0.1f * Mathf.Pow(velocity.z, 2) * areaFacingWindStream / 2;
        if (velocity.z < aircraft.StallVelocity)
            return 2.82f * rb.mass;
        else
        return 9.82f * rb.mass;
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

    public float LeftAileronExtension
    {
        get { return leftAileronExtension;}
        set { leftAileronExtension = value; }
    }

    public float RightAileronExtension
    {
        get { return rightAileronExtension; }
        set { rightAileronExtension = value; }
    }
}
