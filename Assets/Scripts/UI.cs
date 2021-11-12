using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] Text forwardVel;
    [SerializeField] Text upwardVel;
    [SerializeField] Text upwardAcc;
    [SerializeField] Text forwardAcc;

    [SerializeField] AircraftPhysics aircraftPhy;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //aircraft.ElevatorExtension = elevatorControlScrolbar.value;
        forwardVel.text = aircraftPhy.ForwardVelocity.ToString();
        upwardVel.text = aircraftPhy.UpwardVelocity.ToString();
        upwardAcc.text = aircraftPhy.UpwardAcc.ToString();
        forwardAcc.text = aircraftPhy.ForwardAcc.ToString();
    }
}
