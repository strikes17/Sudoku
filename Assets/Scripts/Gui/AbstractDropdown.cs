namespace SudokuGame.Gameplay.Gui
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class AbstractDropdown : MonoBehaviour
    {
        [SerializeField]
        protected TMP_Dropdown dropdown = default;

        protected virtual void Awake()
        {
            if (dropdown == null)
            {
                dropdown = GetComponent<TMP_Dropdown>();
            }
        }

        protected virtual void OnEnable() => dropdown.onValueChanged.AddListener(OnDropdownChanged);

        protected virtual void OnDisable() => dropdown.onValueChanged.RemoveListener(OnDropdownChanged);

        protected abstract void OnDropdownChanged(int option);
    }
}
