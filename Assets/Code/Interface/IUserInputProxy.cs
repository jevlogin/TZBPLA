using System;


namespace WORLDGAMEDEVELOPMENT
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}