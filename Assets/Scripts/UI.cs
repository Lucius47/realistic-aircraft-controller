using UnityEngine.UI;
using UnityEngine;

// Displays velocities, accelerations, altitude, pitch, roll, thrust, and yaw indicators on a canvas overlayed on screen.

public class UI : MonoBehaviour
{
    [SerializeField] Text forwardVel;
    [SerializeField] Text upwardVel;
    [SerializeField] Text upwardAcc;
    [SerializeField] Text forwardAcc;
    [SerializeField] Text altitude;


    [SerializeField] Slider engineThrustIndicator;
    [SerializeField] Slider pitchIndicator;
    [SerializeField] Slider rollIndicator;
    [SerializeField] Slider yawIndicator;

    [SerializeField] AircraftPhysics ap; //gets values from AircraftPhysics component attached to the Aircraft.


    void Update()
    {
        forwardVel.text = ap.Velocity.z.ToString();
        upwardVel.text = ap.Velocity.y.ToString();
        upwardAcc.text = ap.UpwardAcc.ToString();
        forwardAcc.text = ap.ForwardAcc.ToString();
        altitude.text = ap.Altitude.ToString();

        engineThrustIndicator.value = ap.EngineThrustPercentage * 100;
        pitchIndicator.value = ap.ElevatorExtension;
        rollIndicator.value = ap.AileronExtension;
        yawIndicator.value = ap.RudderExtension;
    }
}
