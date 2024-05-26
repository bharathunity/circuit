using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Circuit
{
    public class UiHandler : MonoBehaviour
    {


        [SerializeField] private Transform _speedoMeterNeedle;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        public void UpdateSpeedoMeterValue(float rpm)
        {
            float degreesPerFrame = (rpm * 60 * Time.deltaTime) / 60f;
            float newYrotation = transform.localRotation.z + degreesPerFrame;
            _speedoMeterNeedle.localRotation = Quaternion.Euler(0f, 0, -newYrotation);
            // Debug.Log($"rpm {rpm} \t");
        }


    }
}

