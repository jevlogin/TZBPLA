using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace WORLDGAMEDEVELOPMENT
{
    [RequireComponent(typeof(Button))]
    public sealed class UIButtonInfo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDisposable
    {
        public bool IsButtonDown { get; private set; }

        public event Action<bool> IsDownButtonAction;

        public void Dispose()
        {
            IsDownButtonAction = null;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsButtonDown = true;
            IsDownButtonAction?.Invoke(IsButtonDown);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsButtonDown = false;
            IsDownButtonAction?.Invoke(IsButtonDown);
        }
    }
}