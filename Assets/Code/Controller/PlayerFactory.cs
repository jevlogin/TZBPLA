using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class PlayerFactory
    {
        #region Fields

        private PlayerData _playerData;
        private PlayerModel _playerModel;

        #endregion


        #region ClassLifeCycles

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        #endregion


        #region Methods

        internal PlayerModel CreatePlayerModel()
        {
            if (_playerModel == null)
            {
                var playerStruct = _playerData.PlayerStruct;
                var playerComponents = new PlayerComponents();
                playerComponents.TransformPlayer = _playerData.PlayerComponents.TransformPlayer;
                playerComponents.RigidbodyPlayer = _playerData.PlayerComponents.RigidbodyPlayer;
                playerComponents.AirPlaneView = _playerData.PlayerComponents.AirPlaneView;

                var playerSpawn = Object.Instantiate(_playerData.PlayerStruct.Prefab).GetComponent<AirPlaneView>();

                playerComponents.RigidbodyPlayer = playerSpawn.GetComponent<Rigidbody>();
                playerComponents.RigidbodyPlayer.isKinematic = playerStruct.IsKinematicControl;
                playerComponents.TransformPlayer = playerSpawn.GetComponent<Transform>();
                playerComponents.AirPlaneView = playerSpawn;

                _playerModel = new PlayerModel(playerStruct, playerComponents);
            }
            return _playerModel;
        }

        #endregion
    }
}