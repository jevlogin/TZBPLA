using System.IO;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 51)]
    public sealed class Data : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _playerDataPath;

        private PlayerData _playerData;

        #endregion


        #region Properties

        internal PlayerData PlayerData
        {
            get
            {
                if (_playerData == null)
                {
                    _playerData = Resources.Load<PlayerData>(Path.Combine(ManagerPath.DATA, ManagerPath.PLAYER, ManagerPath.PLAYERDATA));
                }
                if (_playerData == null)
                {
                    _playerData = Resources.Load<PlayerData>(Path.Combine(ManagerPath.DATA, _playerDataPath));
                }
                return _playerData;
            }
        }

        #endregion
    }
}