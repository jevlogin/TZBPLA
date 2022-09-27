using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    internal sealed class PlayerData : ScriptableObject
    {
        #region Fields

        [SerializeField] private PlayerStruct _playerStruct;
        [SerializeField] private PlayerComponents _playerComponents;

        #endregion


        #region Properties

        public PlayerStruct PlayerStruct { get => _playerStruct; }
        public PlayerComponents PlayerComponents { get => _playerComponents; }

        #endregion
    }
}