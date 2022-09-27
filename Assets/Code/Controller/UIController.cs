using System;
using System.Collections.Generic;
using UnityEngine.UI;


namespace WORLDGAMEDEVELOPMENT
{
    internal sealed class UIController : IInitialization, IDisposable
    {
        private ControlUIView _uiView;
        private List<Button> _eventsButton;

        public ControlUIView ControlUIView => _uiView;

        internal UIController(UiInitialization uIInitialization)
        {
            _uiView = uIInitialization.ControlUIView;
            _eventsButton = new List<Button>();
        }

        public void Dispose()
        {
            foreach (var button in _eventsButton)
            {
                button.onClick.RemoveAllListeners();
            }
            _eventsButton.Clear();
        }

        public void Initialization()
        {
            _eventsButton.Add(_uiView.ButtonAccelerateUp);
            _eventsButton.Add(_uiView.ButtonAccelerateDown);
            _eventsButton.Add(_uiView.ButtonSwitchCam);
            _eventsButton.Add(_uiView.ButtonW);
            _eventsButton.Add(_uiView.ButtonS);
            _eventsButton.Add(_uiView.ButtonA);
            _eventsButton.Add(_uiView.ButtonD);
        }
    }
}