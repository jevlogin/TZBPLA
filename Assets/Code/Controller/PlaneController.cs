using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PlaneController : IInitialization, ICleanup, IExecute
    {
        #region Fields

        private InputController _inputController;
        private PlayerModel _playerModel;
        private CameraInitialization _cameraInitialization;

        private float _verticalInput;
        private float _horizontalInput;
        private float _yaw;
        private bool _isActivatedSpeed;
        private float _maxDegreePitch;
        private float _maxDegreeRoll;
        private float _pitch;
        private float _roll;

        private float _smoothAngle;
        private bool _isPressedButtonW;
        private bool _isPressedButtonS;
        private bool _isPressedButtonA;
        private bool _isPressedButtonD;

        #endregion


        #region ClassLifeCycles

        public PlaneController(InputController inputController, PlayerModel playerModel, CameraInitialization cameraInitialization)
        {
            _inputController = inputController;
            _playerModel = playerModel;
            _cameraInitialization = cameraInitialization;
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _inputController.InputHorizontal.AxisOnChange += InputHorizontal;
            _inputController.InputVertical.AxisOnChange += InputVertical;
            _maxDegreePitch = _playerModel.PlayerStruct.MaxDegreePitch;
            _maxDegreeRoll = _playerModel.PlayerStruct.MaxDegreeRoll;
            _smoothAngle = _playerModel.PlayerStruct.SmoothAngle;
        }

        #endregion


        #region Methods

        private void InputVertical(float value)
        {
            _verticalInput = value;
        }

        private void InputHorizontal(float value)
        {
            _horizontalInput = value;
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            _inputController.InputHorizontal.AxisOnChange -= InputHorizontal;
            _inputController.InputVertical.AxisOnChange -= InputVertical;
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            if (Input.GetButtonDown(ManagerAxis.JUMP))
                ActivatedAndDeactivatedAccelerate();

            if (_isActivatedSpeed)
            {
                _playerModel.PlayerComponents.TransformPlayer.position += _playerModel.PlayerComponents.TransformPlayer.forward *
                                                                                 _playerModel.PlayerStruct.FlySpeed * deltaTime;

                Pitch();
                Roll(deltaTime);

                _playerModel.PlayerComponents.TransformPlayer.localRotation =
                    Quaternion.Euler(Vector3.up * _yaw + Vector3.right * _pitch + Vector3.forward * _roll);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchCams();
            }
        }

        #endregion


        #region Methods

        private void Roll(float deltaTime)
        {
            if (_isPressedButtonA)
            {
                _yaw += -_smoothAngle * _playerModel.PlayerStruct.YawAmmount * deltaTime;
                _roll = Mathf.Lerp(0, _maxDegreeRoll, Mathf.Abs(_smoothAngle)) * Mathf.Sign(_smoothAngle);
            }
            else if (_isPressedButtonD)
            {
                _yaw += _smoothAngle * _playerModel.PlayerStruct.YawAmmount * deltaTime;
                _roll = Mathf.Lerp(0, _maxDegreeRoll, Mathf.Abs(_smoothAngle)) * -Mathf.Sign(_smoothAngle);
            }
            else
            {
                _yaw += _horizontalInput * _playerModel.PlayerStruct.YawAmmount * deltaTime;
                _roll = Mathf.Lerp(0, _maxDegreeRoll, Mathf.Abs(_horizontalInput)) * -Mathf.Sign(_horizontalInput);
            }
        }

        private void Pitch()
        {
            if (_isPressedButtonW)
            {
                _pitch = Mathf.Lerp(0, _maxDegreePitch, _smoothAngle);
            }
            else if (_isPressedButtonS)
            {
                _pitch = -Mathf.Lerp(0, _maxDegreePitch, _smoothAngle);
            }
            else
            {
                _pitch = Mathf.Lerp(0, _maxDegreePitch, Mathf.Abs(_verticalInput)) * Mathf.Sign(_verticalInput);
            }
        }

        private void ActivatedAndDeactivatedAccelerate()
        {
            _isActivatedSpeed = !_isActivatedSpeed;
        }

        private void SwitchCams()
        {
            if (_cameraInitialization.CameraVirtualIn.Priority < _cameraInitialization.CameraVirtualOut.Priority)
            {
                _cameraInitialization.CameraVirtualIn.Priority = byte.MaxValue;
                _cameraInitialization.CameraVirtualOut.Priority = byte.MinValue;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                _cameraInitialization.CameraVirtualIn.Priority = byte.MinValue;
                _cameraInitialization.CameraVirtualOut.Priority = byte.MaxValue;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        internal void SendActionButtons(UIController uIController)
        {
            uIController.ControlUIView.ButtonSwitchCam.onClick.AddListener(SwitchCams);
            uIController.ControlUIView.ButtonAccelerateUp.onClick.AddListener(() =>
            {
                if (_isActivatedSpeed)
                    return;
                _isActivatedSpeed = true;
            });
            uIController.ControlUIView.ButtonAccelerateDown.onClick.AddListener(() =>
            {
                if (!_isActivatedSpeed)
                    return;
                _isActivatedSpeed = false;
            });

            var buttonInfoW = uIController.ControlUIView.ButtonW.GetComponent<UIButtonInfo>();
            buttonInfoW.IsDownButtonAction += ButtonInfoW_IsDownButtonAction;

            var buttonInfoS = uIController.ControlUIView.ButtonS.GetComponent<UIButtonInfo>();
            buttonInfoS.IsDownButtonAction += ButtonInfoS_IsDownButtonAction;

            var buttonInfoA = uIController.ControlUIView.ButtonA.GetComponent<UIButtonInfo>();
            buttonInfoA.IsDownButtonAction += ButtonInfoA_IsDownButtonAction;

            var buttonInfoD = uIController.ControlUIView.ButtonD.GetComponent<UIButtonInfo>();
            buttonInfoD.IsDownButtonAction += ButtonInfoD_IsDownButtonAction;
        }

        private void ButtonInfoD_IsDownButtonAction(bool value)
        {
            _isPressedButtonD = value;
        }

        private void ButtonInfoA_IsDownButtonAction(bool value)
        {
            _isPressedButtonA = value;
        }

        private void ButtonInfoS_IsDownButtonAction(bool value)
        {
            _isPressedButtonS = value;
        }

        private void ButtonInfoW_IsDownButtonAction(bool value)
        {
            _isPressedButtonW = value;
        }

        #endregion
    }
}