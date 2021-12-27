using UnityEngine;

// Stores properties specific to a vertain aircraft. Such as engine power, wings area, drag and lift coefficients,
// mass, max operational altitude etc.

public class Aircraft : MonoBehaviour
{
    [SerializeField] float enginePower;
    //[SerializeField] float stallVelocity;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.inertiaTensorRotation = Quaternion.identity;
        rb.centerOfMass = Vector3.zero;
    }

    public float EnginePower
    {
        get { return enginePower; }
    }

    
}
