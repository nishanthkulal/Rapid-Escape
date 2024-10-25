using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelColider;
    [SerializeField] private WheelCollider frontLeftWheelColider;
    [SerializeField] private WheelCollider backRightWheelColider;
    [SerializeField] private WheelCollider backLeftWheelColider;

    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;

    [SerializeField] private float speed;
    [SerializeField] private float breakAmount;
    [SerializeField] private float SteeringAngle;
    [SerializeField] private Transform carCenterofmass;
    [SerializeField] private Rigidbody rb;
    private float verticalInput, horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = carCenterofmass.localPosition;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoterSpeed();
        UpdateWheel();
        GetInput();
        Steering();
        BreakSystem();

    }
    private void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void MoterSpeed()
    {
        frontRightWheelColider.motorTorque = speed * verticalInput;
        frontLeftWheelColider.motorTorque = speed * verticalInput;
        //backRightWheelColider.motorTorque = 10f;
       // backLeftWheelColider.motorTorque = 10f;
      
    }
    private void Steering()
    {
        frontRightWheelColider.steerAngle = SteeringAngle * horizontalInput;
        frontLeftWheelColider.steerAngle = SteeringAngle * horizontalInput;
    }

    private void BreakSystem()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            //bug.Log("break");
        frontRightWheelColider.brakeTorque = breakAmount;
        frontLeftWheelColider.brakeTorque = breakAmount;
        backRightWheelColider.brakeTorque = breakAmount;
        backLeftWheelColider.brakeTorque = breakAmount;
        }else
        {
            frontRightWheelColider.brakeTorque = 0f;
            frontLeftWheelColider.brakeTorque = 0f;
            backRightWheelColider.brakeTorque = 0f;
            backLeftWheelColider.brakeTorque = 0f;
        }


    }
    private void UpdateWheel()
    {
        RotateWheel(frontRightWheelColider, frontRightWheelTransform);
        RotateWheel(frontLeftWheelColider, frontLeftWheelTransform);
        RotateWheel(backRightWheelColider, backRightWheelTransform);
        RotateWheel(backLeftWheelColider, backLeftWheelTransform);

    }

    private void RotateWheel(WheelCollider wheelCollider,Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
