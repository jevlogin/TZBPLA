using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    [Serializable]
    public sealed class PlayerComponents
    {
        #region Fields
        
        public Transform TransformPlayer;
        public Rigidbody RigidbodyPlayer;
        public AirPlaneView AirPlaneView;

        #endregion
    }
}