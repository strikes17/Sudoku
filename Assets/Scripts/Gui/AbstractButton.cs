namespace SudokuGame.Gameplay.Gui
{
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class AbstractButton : MonoBehaviour
    {
        [SerializeField]
        protected Button button = default;

        protected virtual void Awake()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
        }

        protected virtual void OnEnable() => button.onClick.AddListener(OnButtonClicked);

        protected virtual void OnDisable() => button.onClick.RemoveListener(OnButtonClicked);

        protected abstract void OnButtonClicked();
    }
}
