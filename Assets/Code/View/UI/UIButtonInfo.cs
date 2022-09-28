using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace WORLDGAMEDEVELOPMENT
{
    [RequireComponent(typeof(Button))]
    public sealed class UIButtonInfo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDisposable
    {
        #region Fields

        public event Action<bool> IsDownButtonAction;

        #endregion


        #region Properties

        public bool IsButtonDown { get; private set; }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            IsDownButtonAction = null;
        }

        #endregion


        #region IPointerDownHandler

        public void OnPointerDown(PointerEventData eventData)
        {
            IsButtonDown = true;
            IsDownButtonAction?.Invoke(IsButtonDown);
        }

        #endregion


        #region IPointerUpHandler

        public void OnPointerUp(PointerEventData eventData)
        {
            IsButtonDown = false;
            IsDownButtonAction?.Invoke(IsButtonDown);
        }

        #endregion
    }
}