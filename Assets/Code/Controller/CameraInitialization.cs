using Cinemachine;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class CameraInitialization : IInitialization
    {
        #region Fields

        private CinemachineVirtualCamera _virtualCameraIn;
        private CinemachineVirtualCamera _virtualCameraOut;
        private PlayerModel _playerModel;

        #endregion


        #region Properties

        public CinemachineVirtualCamera CameraVirtualIn => _virtualCameraIn;
        public CinemachineVirtualCamera CameraVirtualOut => _virtualCameraOut;

        #endregion


        #region ClassLifeCycles

        public CameraInitialization(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Initialization()
        {
            var camObjectIn = new GameObject("CameraIn");
            var camObjectOut = new GameObject("CameraOut");

            _virtualCameraIn = camObjectIn.AddComponent<CinemachineVirtualCamera>();
            _virtualCameraOut = camObjectOut.AddComponent<CinemachineVirtualCamera>();

            _virtualCameraOut.AddCinemachineComponent<CinemachineTransposer>();
            _virtualCameraOut.AddCinemachineComponent<CinemachineComposer>();
            _virtualCameraIn.AddCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = 0.2f;
            _virtualCameraIn.AddCinemachineComponent<CinemachinePOV>();

            CameraVirtualOut.Follow = _playerModel.PlayerComponents.AirPlaneView.TargetOut;
            CameraVirtualOut.LookAt = _playerModel.PlayerComponents.AirPlaneView.TargetIn;
            CameraVirtualOut.Priority = byte.MaxValue;

            CameraVirtualIn.Follow = _playerModel.PlayerComponents.AirPlaneView.TargetIn;
            CameraVirtualIn.LookAt = _playerModel.PlayerComponents.AirPlaneView.TargetIn;
        }

        #endregion
    }
}