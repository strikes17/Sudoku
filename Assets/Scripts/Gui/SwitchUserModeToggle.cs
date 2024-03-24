namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;

    public class SwitchUserModeToggle : AbstractToggle
    {
        [SerializeField]
        protected UserModeContainer userModeContainer = default;

        [SerializeField]
        protected UserMode userModeOnActive = default;

        [SerializeField]
        protected UserMode userModeOnDisable = default;

        protected override void OnEnable()
        {
            base.OnEnable();
            userModeContainer.onDataChanged += SetState;
            SetState(userModeContainer.Data);
        }

        protected override void OnDisable()
        {
            base.OnEnable();
            userModeContainer.onDataChanged -= SetState;
        }

        protected virtual void SetState(UserMode userMode)
        {
            if (userMode == userModeOnActive)
            {
                toggle.SetIsOnWithoutNotify(true);
            }
            else
            {
                toggle.SetIsOnWithoutNotify(false);
            }
        }

        protected override void OnToggleChanged(bool isActive)
        {
            if (isActive)
            {
                userModeContainer.Data = userModeOnActive;
            }
            else
            {
                userModeContainer.Data = userModeOnDisable;
            }
        }
    }
}
