using Circuit;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




namespace Circuit
{
    public interface ICarControl
    {
        bool StartCar();
        void MoveCar();
        void StopCar();
    }

    public class CarController : MonoBehaviour, ICarControl
    {
        #region Serialize private fields
        [Space]
        [SerializeField] UiHandler _uiHandler;
        [SerializeField] CarWheelController _carWheelController;
/*        [Space(20)]
        [SerializeField] Button _accelerationButton;
        [SerializeField] Button _breakingButton;*/
        #endregion

        #region Private fields
        private VehicleController _vehicleController;
        #endregion

        #region Monobehaviour callbacks

        private void Awake()
        {
            _uiHandler = GameObject.FindObjectOfType<UiHandler>();
            _vehicleController = new VehicleController();
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnEnable()
        {
            _vehicleController?.Enable();
            StartCar();
        }

        private void OnDisable()
        {
            _vehicleController?.Disable();
        }

        // Update is called once per frame
        void Update()
        {

            MoveCar();

            StopCar();

            // _uiHandler.UpdateSpeedoMeterValue(_carWheelController.GetWheelRPM());

        }

        private void OnDestroy()
        {
            StopCar();
        }
        #endregion



        #region ICar implements

        public bool StartCar()
        {
            return true;
        }

        public void MoveCar()
        {
            Vector2 move = Vector2.zero;
            _vehicleController.Car.acceleration.performed += ctx =>
            {

                move = ctx.ReadValue<Vector2>().normalized;
                _carWheelController.Acceleration(move.y);
                _carWheelController.TurnSide(move.x);
                
                
                Debug.Log($"move \t {move}");
            };

            _vehicleController.Car.acceleration.canceled += ctx =>
            {
                /*move.y = Mathf.Lerp(move.y, 0, Time.deltaTime);
                _carWheelController.Acceleration(move.y);

                Debug.Log($"move \t {move}");*/
            };
        }

        public void StopCar()
        {
            bool breakValue = false;
            _vehicleController.Car.brake.started += ctx =>
            {
                breakValue = ctx.ReadValueAsButton();
                Debug.Log($"Break \t {breakValue}");
                _carWheelController.Breaking(breakValue);
            };
            
            _vehicleController.Car.brake.canceled += ctx =>
            {
                breakValue = ctx.ReadValueAsButton();
                Debug.Log($"Break \t {breakValue}");
                _carWheelController.Breaking(breakValue);
            };


        }
        #endregion


    }

}
