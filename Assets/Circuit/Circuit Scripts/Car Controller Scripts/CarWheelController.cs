using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Circuit
{
    public class CarWheelController : MonoBehaviour
    {
        #region Serialize private fields
        

        [SerializeField] WheelCollider frontLeftWheel;
        [SerializeField] WheelCollider frontRightWheel;
        [SerializeField] WheelCollider backLeftWheel;
        [SerializeField] WheelCollider backRightWheel;

        [SerializeField] Transform frontLeftTransform;
        [SerializeField] Transform frontRightTransform;
        [SerializeField] Transform backLeftTransform;
        [SerializeField] Transform backRightTransform;
        #endregion

        [SerializeField] private float _acceleration     = 500f;
        [SerializeField] private float _breakingForce    = 300f;
        [SerializeField] private float _maxTurnAngle     = 15f;

        private float currentAcceleration   = 0.0f;
        private float currentBreakingForce  = 0.0f;
        private float currentTurnAngle = 0.0f;
        

        public float WheelRPM { get; private set; }

        #region Monobehaviour callbacks
        // Start is called before the first frame update
        void Start()
        {
            
        }

        

        private void FixedUpdate()
        {


            
        }


        private void LateUpdate()
        {
            

            // Debug.Log($"Wheel RPM {backLeftWheel.}");
        }

        #endregion



        internal void Acceleration(float moveY)
        {
            currentAcceleration = _acceleration * moveY; // Input.GetAxis("Vertical");

            frontRightWheel.motorTorque = currentAcceleration;
            frontLeftWheel.motorTorque = currentAcceleration;

            Debug.Log($"{nameof(Acceleration)} \t current acceleration {currentAcceleration}");
        }

        internal void TurnSide(float moveX)
        {
            currentTurnAngle = _maxTurnAngle * moveX; //Input.GetAxis("Horizontal");
            frontLeftWheel.steerAngle = currentTurnAngle;
            frontRightWheel.steerAngle = currentTurnAngle;

            Debug.Log($"{nameof(TurnSide)} \t Turn angle {currentTurnAngle} \t Move X {moveX}");

            /*UpdateWheel(frontLeftWheel, frontLeftTransform);
            UpdateWheel(frontRightWheel, frontRightTransform);
            UpdateWheel(backLeftWheel, backLeftTransform);
            UpdateWheel(backRightWheel, backLeftTransform);*/
        }

                
        void UpdateWheel(WheelCollider wheelCollider)
        {
            
        }

        /// <summary>
        /// Update the wheel position and rotation.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="trans"></param>
        void UpdateWheel(WheelCollider col, Transform trans)
        {
            Vector3 position;
            Quaternion rotation;
            col.GetWorldPose(out position, out rotation);

            trans.position = position;
            trans.rotation = rotation;
        }

        internal void Breaking(bool breakValue)
        {
            currentBreakingForce =  (breakValue) ? _breakingForce : 0.0f;

            frontRightWheel.brakeTorque = currentBreakingForce;
            frontLeftWheel.brakeTorque = currentBreakingForce;
            backRightWheel.brakeTorque = currentBreakingForce;
            backLeftWheel.brakeTorque = currentBreakingForce;

            Debug.Log($"{nameof(Breaking)} \t break value {breakValue}");
        }

        internal float GetWheelRPM()
        {
            WheelRPM = backLeftWheel.rpm;
            WheelRPM = Mathf.Clamp(WheelRPM, -700f, 700f);
            // Debug.Log($"Wheel RPM {MathF.Round(Mathf.Abs(WheelRPM))}");
            return WheelRPM;
            
        }
    }

}
