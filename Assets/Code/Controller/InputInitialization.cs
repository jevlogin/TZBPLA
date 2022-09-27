namespace WORLDGAMEDEVELOPMENT
{
    public sealed class InputInitialization : IEmptyInitialization
    {
        #region Fields

        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;

        #endregion


        #region IEmptyInitialization

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
        }

        #endregion


        #region Methods

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) ActiveInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        #endregion
    }
}