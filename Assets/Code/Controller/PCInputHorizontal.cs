using System;
using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate (float value) { };

        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(ManagerAxis.HORIZONTAL));
        }
    }
}