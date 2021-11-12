using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftPartsMotion : MonoBehaviour
{
    [SerializeField] Transform propeller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        propeller.Rotate(Vector3.up * 10000 * Time.deltaTime);
    }
}
