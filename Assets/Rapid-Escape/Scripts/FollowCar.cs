using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    [SerializeField] private Transform carTransform;
    [SerializeField] private Transform cameraTransformPosition;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(carTransform);
        transform.position = Vector3.SmoothDamp(transform.position, cameraTransformPosition.position, ref velocity, 5f*Time.deltaTime);

    }
}
