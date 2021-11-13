using UnityEngine;

// Gets input from keyboard or joystick and sends it to AircraftPhysics.

public class InputController : MonoBehaviour
{
    AircraftPhysics ap;
    float engineThrustPercentage = 100; // 0 - 100%

    void Start()
    {
        ap = GetComponent<AircraftPhysics>();
    }

    void Update()
    {
        float rollAxis = Input.GetAxis("Horizontal");
        float pitchAxis = Input.GetAxis("Vertical");
        float yawAxis = Input.GetAxis("Yaw");
        float engineThrustAxis = Input.GetAxis("EngineThrust");

        engineThrustPercentage += engineThrustAxis;
        engineThrustPercentage = Mathf.Clamp(engineThrustPercentage, 0, 100);

        ap.EngineThrustPercentage = engineThrustPercentage;
        ap.ElevatorExtension = pitchAxis;
        ap.RudderExtension = yawAxis;
        ap.AileronExtension = rollAxis;
    }
}
