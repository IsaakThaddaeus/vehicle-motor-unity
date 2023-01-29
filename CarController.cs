using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider fr;
    [SerializeField] WheelCollider fl;
    [SerializeField] WheelCollider br;
    [SerializeField] WheelCollider bl;

    [SerializeField] Transform frModell;
    [SerializeField] Transform flModell;
    [SerializeField] Transform brModell;
    [SerializeField] Transform blModell;


    public float acceleration  = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngule = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce   = 0f;
    private float currentTurnAngle    = 0f;


    private void FixedUpdate()
    {

        currentAcceleration = acceleration * Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        
        else
            currentBreakForce = 0f;


        fr.motorTorque = currentAcceleration;
        fl.motorTorque = currentAcceleration;
        br.motorTorque = currentAcceleration;
        bl.motorTorque = currentAcceleration;

        fr.brakeTorque = currentBreakForce;
        fl.brakeTorque = currentBreakForce;
        br.brakeTorque = currentBreakForce;
        bl.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngule * Input.GetAxis("Horizontal");
        fl.steerAngle = currentTurnAngle;
        fr.steerAngle = currentTurnAngle;

        UpdateWheelPose(fl, flModell);
        UpdateWheelPose(fr, frModell);
        UpdateWheelPose(bl, blModell);
        UpdateWheelPose(br, brModell);
    }


    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

}
