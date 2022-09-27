using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public struct PlayerStruct
    {
        #region Fields

        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _flySpeed;
        [SerializeField] private bool _isKinematicControl;
        [SerializeField] private float _yawAmmount;
        [SerializeField] private float _maxDegreePitch;
        [SerializeField] private float _maxDegreeRoll;
        [SerializeField] private float _smoothAngle;

        #endregion


        #region Properties

        public GameObject Prefab => _prefab;
        public float FlySpeed => _flySpeed;
        public bool IsKinematicControl => _isKinematicControl;
        public float YawAmmount => _yawAmmount;
        public float MaxDegreePitch => _maxDegreePitch;
        public float MaxDegreeRoll => _maxDegreeRoll;
        public float SmoothAngle => _smoothAngle;

        #endregion
    }
}