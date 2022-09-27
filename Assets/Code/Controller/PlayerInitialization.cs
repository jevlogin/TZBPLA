namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class PlayerInitialization
    {
        #region Fields

        private PlayerModel _playerModel;

        #endregion


        #region Properties

        public PlayerModel PlayerModel { get => _playerModel; } 

        #endregion


        #region ClassLifeCycles

        public PlayerInitialization(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        } 

        #endregion
    }
}