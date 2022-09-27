using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PCInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float value) { };

        public void GetAxis()
        {
            var vertical = Input.GetAxis(ManagerAxis.VERTICAL);
            AxisOnChange.Invoke(vertical);
        }
    }
}