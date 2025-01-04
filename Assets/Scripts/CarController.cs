using System;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Axel
    {
        Front, 
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public Axel axel;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;
    public float wheelFriction = 2.0f;
    public float steerFactor = 50.0f;


    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;
    float currentSpeed;

    private Rigidbody carRb;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
    }

    void Update()
    {
        GetInputs();
        AnimationWheels();
        WheelEffects();
        currentSpeed = carRb.velocity.magnitude;
        turnSensitivity = 1 - (currentSpeed / steerFactor); // para ajustar la sensitivity, interesa que sea menor a mas velocidad
    }

    void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }


 
    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput *600* maxAcceleration * Time.deltaTime;
        }
        
        }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, turnSensitivity);
                WheelFrictionCurve friction = wheel.wheelCollider.sidewaysFriction;
                friction.stiffness = wheelFriction; 
                wheel.wheelCollider.sidewaysFriction = friction;
            }
            
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 600 * brakeAcceleration * Time.deltaTime;
            }
        }
        else {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        
        }


        
        }
    void AnimationWheels()
    {
        foreach(var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;


        }
    }

    void WheelEffects()
    {
        foreach (var wheel in wheels)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = true;
            }
            else
            {
                wheel.wheelEffectObj.GetComponentInChildren<TrailRenderer>().emitting = false;
            }
        }
        }
    }


