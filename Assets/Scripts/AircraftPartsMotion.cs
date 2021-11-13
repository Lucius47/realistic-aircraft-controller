using UnityEngine;

// Gives motion to aircraft parts such as propellers, flaps, ailerons, elevator, rudder, and landing gear.
// Currently, only propellers are rotated independant of anything.

public class AircraftPartsMotion : MonoBehaviour
{
    [SerializeField] Transform propeller;

    
    void Update()
    {
        propeller.Rotate(Vector3.up * 10000 * Time.deltaTime);
    }
}
