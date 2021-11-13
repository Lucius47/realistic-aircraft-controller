using UnityEngine;

// Controls the interaction of the aircraft with the world.

public class AircraftPhysics : MonoBehaviour
{
    Aircraft aircraft;
    Rigidbody rb;

    float gravity = 98.1f;

    float engineThrustPercentage;
    float aileronExtension;
    float elevatorExtension;
    float rudderExtension;
    float lastUpVelocity;
    float lastForwardVelocity;
    float accelerationY;
    float accelerationZ;
    


    void Awake()
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

        // Calculates acceleration. Has some issues.
        accelerationY = (Velocity.y - lastUpVelocity) / Time.fixedDeltaTime;
        lastUpVelocity = Velocity.y;
        accelerationZ = (Velocity.z - lastForwardVelocity) / Time.fixedDeltaTime;
        lastForwardVelocity = Velocity.z;
    }

    #region
    void ApplyEngineThrust()
    {
        rb.AddForce(transform.forward * (engineThrustPercentage * aircraft.EnginePower));
        //Debug.DrawRay(aircraft.EngineThrustPosition, transform.forward * engineThrustPercentage * 10, Color.red);
    }

    void ApplyDrag()
    {
        rb.AddForce(-transform.forward * Mathf.Pow(Velocity.z, 2) * 0.001f);
    }

    void ApplyGravity()
    {
        rb.AddForce(Vector3.down * gravity * rb.mass);
    }

    void ApplyWingsLift()
    {
        rb.AddForce(Vector3.up * CalculateWingsLift());
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
        //print(AngleWithHorizon);
        //if (AngleWithHorizon > 0 && AngleWithHorizon < 90)
        //{
            //rb.AddTorque(transform.forward * 10);
        //}
        //if (AngleWithHorizon > 90 && AngleWithHorizon < 180)
        //{
            //rb.AddTorque(transform.forward * -10);
        //}
    }

    float CalculateWingsLift()
    {
        float lift = Velocity.z;
        lift = Mathf.Clamp(lift, 2, gravity * rb.mass);
        return lift;
    }
    #endregion

    #region
    public Vector3 Velocity
    {
        get { return transform.InverseTransformDirection(rb.velocity); }
    }

    public float Altitude
    {
        get { return transform.position.y; }
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

    public float AngleWithHorizon
    {
        // Does not work as intended
        get { return Vector3.SignedAngle(Vector3.ProjectOnPlane(transform.up, transform.forward), Vector3.up, transform.forward); }
    }
    #endregion

}
