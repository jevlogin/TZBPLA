namespace WORLDGAMEDEVELOPMENT
{
    public sealed class InputController : IExecute
    {
        #region Fields

        private IUserInputProxy _inputHorizontal;
        private IUserInputProxy _inputVertical;

        #endregion


        #region Properties

        public IUserInputProxy InputHorizontal { get => _inputHorizontal; private set => _inputHorizontal = value; }
        public IUserInputProxy InputVertical { get => _inputVertical; private set => _inputVertical = value; }

        #endregion


        #region ClassLifeCycles

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) activeInput)
        {
            InputHorizontal = activeInput.inputHorizontal;
            InputVertical = activeInput.inputVertical;
            
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            InputHorizontal.GetAxis();
            InputVertical.GetAxis();
        }

        #endregion

    }
}