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

    [SerializeField] AircraftMain aircraft;
    [SerializeField] Slider elevatorControlScrolbar;

    void Start()
    {
        elevatorControlScrolbar.minValue = -1;
        elevatorControlScrolbar.maxValue = 1;
        elevatorControlScrolbar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //aircraft.ElevatorExtension = elevatorControlScrolbar.value;
        forwardVel.text = aircraft.ForwardVelocity.ToString();
        upwardVel.text = aircraft.UpwardVelocity.ToString();
        upwardAcc.text = aircraft.UpwardAcc.ToString();
        forwardAcc.text = aircraft.ForwardAcc.ToString();
    }
}
