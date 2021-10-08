using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AxInfo
{
    public WheelCollider leftWheelColl;
    public WheelCollider rightWheelColl;
    public Transform Rwheel;
    public Transform Lwheel;
    public bool motor;
    public bool steering;
}

public class SimpleCarComponent : MonoBehaviour
{
    public List<AxInfo> axInfos;
    public float maxMotorTorque;
    public float maxBrakeTorque = 300f;
    public float maxSteeringAngle;

    private float _motor;
    private bool _braking;
    private float _steering;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _braking = true;
        else
            _braking = false;

        SteerAngle();
    }

    private void FixedUpdate()
    {
        if (!_braking && TimerCar.startGame)
        {
            _motor = maxMotorTorque * Input.GetAxis("Vertical");
        }
        else
        {
            _motor = 0f;
        }

        _steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxInfo axInfo in axInfos)
        {
            if(axInfo.steering)
            {
                axInfo.leftWheelColl.steerAngle = _steering;
                axInfo.rightWheelColl.steerAngle = _steering;                
            }

            if(axInfo.motor)
            {
                axInfo.leftWheelColl.motorTorque = _motor;
                axInfo.rightWheelColl.motorTorque = _motor;
            }

            if (_braking)
            {
                axInfo.leftWheelColl.brakeTorque = maxBrakeTorque;
                axInfo.rightWheelColl.brakeTorque = maxBrakeTorque;
            }
            else
            {
                axInfo.leftWheelColl.brakeTorque = 0f;
                axInfo.rightWheelColl.brakeTorque = 0f;
            }
        }
    }

    void SteerAngle()
    {
        foreach (AxInfo axInfo in axInfos)
        {
            Vector3 FRposi;
            Quaternion FRquator;
            Vector3 FLposi;
            Quaternion FLquator;

            axInfo.leftWheelColl.GetWorldPose(out FRposi, out FRquator);
            axInfo.rightWheelColl.GetWorldPose(out FLposi, out FLquator);

            axInfo.Rwheel.position = FRposi;
            axInfo.Rwheel.rotation = FRquator;

            axInfo.Lwheel.position = FLposi;
            axInfo.Lwheel.rotation = FLquator;
        }
    }
}
