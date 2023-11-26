using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Menu
{
    public class OptionMenuButtonUIObject : MenuUIObject
    {
        [SerializeField] private OptionMenuManager _optionMenuManager;
        [SerializeField] private Color _baseColor, _unselectedColor;
        [SerializeField] private Image _background;

        public override void Set(bool isActive)
        {
            base.Set(isActive);
            _background.color = isActive ? _baseColor : _unselectedColor;
        }

        public override void Activate(InputAction.CallbackContext context)
        {
            if (IsSelected == false || _optionMenuManager.IsUsable == false)
            {
                return;
            }

            base.Activate(context);
        }
    }
}
