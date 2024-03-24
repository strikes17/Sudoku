namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class AbstractToggle : MonoBehaviour
    {
        [SerializeField]
        protected Toggle toggle = default;

        protected virtual void Awake()
        {
            if (toggle == null)
            {
                toggle = GetComponent<Toggle>();
            }
        }

        protected virtual void OnEnable() => toggle.onValueChanged.AddListener(OnToggleChanged);

        protected virtual void OnDisable() => toggle.onValueChanged.RemoveListener(OnToggleChanged);

        protected abstract void OnToggleChanged(bool isActive);
    }
}
