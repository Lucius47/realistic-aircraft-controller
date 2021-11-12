using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    AircraftPhysics ap;

    float engineThrustPercentage = 100; // 0 - 100%
    void Start()
    {
        ap = GetComponent<AircraftPhysics>();
    }

    // Update is called once per frame
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
