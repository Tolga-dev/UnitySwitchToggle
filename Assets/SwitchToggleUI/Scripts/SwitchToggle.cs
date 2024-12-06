using UnityEngine;
using UnityEngine.UI;

namespace SwitchToggleUI.Scripts
{
   public class SwitchToggle : MonoBehaviour {
      
      [SerializeField] RectTransform uiHandleRectTransform;
      [SerializeField] Color backgroundActiveColor;
      [SerializeField] Color handleActiveColor;

      private Image _backgroundImage, _handleImage;

      private Color _backgroundDefaultColor, _handleDefaultColor;

      private Toggle _toggle;

      private Vector2 _handlePosition;

      private void Awake() {
         _toggle = GetComponent <Toggle>();

         _handlePosition = uiHandleRectTransform.anchoredPosition;

         _backgroundImage = uiHandleRectTransform.parent.GetComponent <Image>();
         _handleImage = uiHandleRectTransform.GetComponent <Image>();

         _backgroundDefaultColor = _backgroundImage.color;
         _handleDefaultColor = _handleImage.color;

         _toggle.onValueChanged.AddListener (OnSwitch);

         if (_toggle.isOn)
            OnSwitch(true);
      }

      private void OnSwitch (bool on) {
         uiHandleRectTransform.anchoredPosition = on ? _handlePosition * -1 : _handlePosition; // no anim

         _backgroundImage.color = on ? backgroundActiveColor : _backgroundDefaultColor; // no anim

         _handleImage.color = on ? handleActiveColor : _handleDefaultColor; // no anim
         
         Debug.Log ("Switched: " + on);
      }

      private void OnDestroy() {
         _toggle.onValueChanged.RemoveListener (OnSwitch);
      }
   }
}
