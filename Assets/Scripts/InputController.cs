using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    AircraftMain am;

    float engineThrustPercentage; // 0 - 100%
    void Start()
    {
        am = GetComponent<AircraftMain>();
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
        //print("Engine Thrust Percentage: " + engineThrustPercentage);
        am.EngineThrustPercentage = engineThrustPercentage;
        am.ElevatorExtension = pitchAxis;
        am.RudderExtension = yawAxis;
        am.LeftAileronExtension = rollAxis;
        am.RightAileronExtension= -rollAxis;
    }
}
