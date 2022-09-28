using System;
using System.Collections.Generic;
using UnityEngine.UI;


namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class UIController : IInitialization, IDisposable
    {
        #region Fields

        private ControlUIView _uiView;
        private List<Button> _eventsButton;

        #endregion


        #region Properties

        public ControlUIView ControlUIView => _uiView;

        #endregion


        #region ClassLifeCycle

        internal UIController(UiInitialization uIInitialization)
        {
            _uiView = uIInitialization.ControlUIView;
            _eventsButton = new List<Button>();
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            foreach (var button in _eventsButton)
            {
                button.onClick.RemoveAllListeners();
            }
            _eventsButton.Clear();
            _uiView.ButtonSwitchHint.onClick.RemoveAllListeners();
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _eventsButton.Add(_uiView.ButtonAccelerateUp);
            _eventsButton.Add(_uiView.ButtonAccelerateDown);
            _eventsButton.Add(_uiView.ButtonSwitchCam);
            _eventsButton.Add(_uiView.ButtonW);
            _eventsButton.Add(_uiView.ButtonS);
            _eventsButton.Add(_uiView.ButtonA);
            _eventsButton.Add(_uiView.ButtonD);
            _uiView.ButtonSwitchHint.onClick.AddListener(SwitchHint);
        }

        #endregion


        #region Methods

        private void SwitchHint()
        {
            foreach (var textMeshPro in _uiView.TextMeshProUGUIs)
            {
                textMeshPro.enabled = !textMeshPro.enabled;
            }
        }

        #endregion
    }
}