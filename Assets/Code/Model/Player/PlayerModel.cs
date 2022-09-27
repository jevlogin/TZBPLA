namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PlayerModel
    {
        #region Fields

        public PlayerStruct PlayerStruct;
        public PlayerComponents PlayerComponents;

        #endregion


        #region ClassLifeCycles

        public PlayerModel(PlayerStruct playerStruct, PlayerComponents playerComponents)
        {
            PlayerStruct = playerStruct;
            PlayerComponents = playerComponents;
        }

        #endregion
    }
}
