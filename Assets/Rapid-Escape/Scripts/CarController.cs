using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelColider;
    [SerializeField] private WheelCollider frontLeftWheelColider;
    [SerializeField] private WheelCollider backRightWheelColider;
    [SerializeField] private WheelCollider backLeftWheelColider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frontRightWheelColider.motorTorque = 10f;
        frontLeftWheelColider.motorTorque = 10f;

    }
}
