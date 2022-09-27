using UnityEngine;


namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class UiInitialization
    {
        #region Fields

        private ControlUIView _controlUIView;

        #endregion


        #region Properties

        public ControlUIView ControlUIView { get => _controlUIView; private set => _controlUIView = value; }

        #endregion


        #region ClassLifeCycles

        public UiInitialization()
        {
            var controlUIView = Resources.Load<ControlUIView>("CanvasControlView");
            ControlUIView = Object.Instantiate(controlUIView);
        }

        #endregion
    }
}