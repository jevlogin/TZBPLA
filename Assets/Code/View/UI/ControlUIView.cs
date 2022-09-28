using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class ControlUIView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Button _buttonW;
        [SerializeField] private Button _buttonS;
        [SerializeField] private Button _buttonA;
        [SerializeField] private Button _buttonD;
        [SerializeField] private Button _buttonAccelerateUp;
        [SerializeField] private Button _buttonAccelerateDown;
        [SerializeField] private Button _buttonSwitchCam;
        [SerializeField] private Button _buttonSwitchHint;
        [SerializeField] private List<TextMeshProUGUI> _textMeshProUGUIs;

        #endregion


        #region Properties

        public Button ButtonW => _buttonW;
        public Button ButtonS => _buttonS;
        public Button ButtonA => _buttonA;
        public Button ButtonD => _buttonD;
        public Button ButtonAccelerateUp => _buttonAccelerateUp;
        public Button ButtonAccelerateDown => _buttonAccelerateDown;
        public Button ButtonSwitchCam => _buttonSwitchCam;
        public Button ButtonSwitchHint => _buttonSwitchHint;
        public List<TextMeshProUGUI> TextMeshProUGUIs => _textMeshProUGUIs;

        #endregion
    }
}

