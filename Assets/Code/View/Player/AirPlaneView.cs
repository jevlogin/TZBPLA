using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class AirPlaneView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Transform _targetIn;
        [SerializeField] private Transform _targetOut;

        #endregion


        #region Properties

        public Transform TargetIn => _targetIn;
        public Transform TargetOut => _targetOut;

        #endregion
    }
}

